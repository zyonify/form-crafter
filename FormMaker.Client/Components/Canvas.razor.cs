using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using FormMaker.Shared.Models;
using FormMaker.Shared.Models.Elements;
using FormMaker.Shared.Enums;

namespace FormMaker.Client.Components;

public partial class Canvas
{
    [Parameter]
    public FormTemplate CurrentTemplate { get; set; } = new FormTemplate();

    [Parameter]
    public EventCallback<FormElement> OnElementSelected { get; set; }

    [Parameter]
    public EventCallback<FormElement> OnElementDropped { get; set; }

    protected override void OnInitialized()
    {
        // Initialize with a default template if needed
        if (CurrentTemplate == null)
        {
            CurrentTemplate = new FormTemplate
            {
                Name = "New Form",
                PageSize = PageSize.Letter
            };
        }
    }

    private string GetPageSizeClass()
    {
        return CurrentTemplate.PageSize switch
        {
            PageSize.A4 => "a4",
            PageSize.Letter => "letter",
            PageSize.Legal => "legal",
            _ => ""
        };
    }

    private void HandleCanvasClick(MouseEventArgs e)
    {
        // Deselect all elements when clicking on empty canvas
        CurrentTemplate.ClearSelection();
        StateHasChanged();
    }

    private void HandleElementClick(FormElement element)
    {
        // Single selection (for now - can add Ctrl+Click for multi-select later)
        CurrentTemplate.ClearSelection();
        element.IsSelected = true;

        OnElementSelected.InvokeAsync(element);
        StateHasChanged();
    }

    private void HandleElementDragStart(FormElement element)
    {
        draggedElement = element;
        showPositionIndicator = true;
    }

    private void HandleDragOver(DragEventArgs e)
    {
        if (draggedElement != null)
        {
            // Calculate snapped position
            int snapX = SnapToGrid((int)e.OffsetX - draggedElement.Width / 2);
            int snapY = SnapToGrid((int)e.OffsetY - draggedElement.Height / 2);

            // Update element position
            draggedElement.X = Math.Max(0, Math.Min(snapX, CurrentTemplate.WidthInPixels - draggedElement.Width));
            draggedElement.Y = Math.Max(0, Math.Min(snapY, CurrentTemplate.HeightInPixels - draggedElement.Height));

            // Check for alignment guides
            CheckAlignmentGuides(draggedElement);

            // Update mouse position for indicator
            mouseX = (int)e.ClientX;
            mouseY = (int)e.ClientY;

            StateHasChanged();
        }
    }

    private async Task HandleDrop(DragEventArgs e)
    {
        if (draggedElement != null)
        {
            // Finalize position
            int snapX = SnapToGrid((int)e.OffsetX - draggedElement.Width / 2);
            int snapY = SnapToGrid((int)e.OffsetY - draggedElement.Height / 2);

            draggedElement.X = Math.Max(0, Math.Min(snapX, CurrentTemplate.WidthInPixels - draggedElement.Width));
            draggedElement.Y = Math.Max(0, Math.Min(snapY, CurrentTemplate.HeightInPixels - draggedElement.Height));

            CurrentTemplate.MarkAsUpdated();

            // Notify parent component
            await OnElementDropped.InvokeAsync(draggedElement);

            // Reset drag state
            draggedElement = null;
            showPositionIndicator = false;
            showAlignmentGuides = false;
            verticalGuidePosition = null;
            horizontalGuidePosition = null;

            StateHasChanged();
        }
    }

    private int SnapToGrid(int value)
    {
        return (int)(Math.Round((double)value / GRID_SIZE) * GRID_SIZE);
    }

    private void CheckAlignmentGuides(FormElement element)
    {
        int canvasWidth = CurrentTemplate.WidthInPixels;
        int canvasHeight = CurrentTemplate.HeightInPixels;
        int centerX = canvasWidth / 2;
        int centerY = canvasHeight / 2;
        int elementCenterX = element.X + element.Width / 2;
        int elementCenterY = element.Y + element.Height / 2;

        // Check for center alignment
        if (Math.Abs(elementCenterX - centerX) < SNAP_THRESHOLD)
        {
            element.X = centerX - element.Width / 2;
            verticalGuidePosition = centerX;
            showAlignmentGuides = true;
        }
        else
        {
            verticalGuidePosition = null;
        }

        if (Math.Abs(elementCenterY - centerY) < SNAP_THRESHOLD)
        {
            element.Y = centerY - element.Height / 2;
            horizontalGuidePosition = centerY;
            showAlignmentGuides = true;
        }
        else
        {
            horizontalGuidePosition = null;
        }

        if (verticalGuidePosition == null && horizontalGuidePosition == null)
        {
            showAlignmentGuides = false;
        }
    }

    private RenderFragment RenderElement(FormElement element) => builder =>
    {
        var style = $"width: 100%; height: 100%; " +
                    $"font-size: {element.Properties.FontSize}px; " +
                    $"font-family: {element.Properties.FontFamily}; " +
                    $"color: {element.Properties.Color}; " +
                    $"background-color: {element.Properties.BackgroundColor}; " +
                    $"border: {element.Properties.BorderWidth}px {element.Properties.BorderStyle} {element.Properties.BorderColor}; " +
                    $"border-radius: {element.Properties.BorderRadius}px; " +
                    $"padding: {element.Properties.GetPaddingCss()}; " +
                    $"text-align: {element.Properties.Alignment.ToString().ToLower()}; " +
                    $"font-weight: {(element.Properties.Bold ? "bold" : "normal")}; " +
                    $"font-style: {(element.Properties.Italic ? "italic" : "normal")}; " +
                    $"text-decoration: {(element.Properties.Underline ? "underline" : "none")};";

        switch (element)
        {
            case TextInputElement textInput:
                builder.OpenElement(0, "input");
                builder.AddAttribute(1, "type", textInput.InputType);
                builder.AddAttribute(2, "placeholder", textInput.Placeholder);
                builder.AddAttribute(3, "value", textInput.DefaultValue);
                builder.AddAttribute(4, "required", textInput.IsRequired);
                builder.AddAttribute(5, "style", style);
                builder.AddAttribute(6, "disabled", true); // Disabled in editor mode
                builder.CloseElement();
                break;

            case LabelElement label:
                var tagName = label.HeadingLevel.ToLower();
                builder.OpenElement(0, tagName);
                builder.AddAttribute(1, "style", style);
                builder.AddContent(2, label.Text);
                builder.CloseElement();
                break;

            case CheckboxElement checkbox:
                builder.OpenElement(0, "label");
                builder.AddAttribute(1, "style", style + " display: flex; align-items: center; gap: 8px;");

                builder.OpenElement(2, "input");
                builder.AddAttribute(3, "type", "checkbox");
                builder.AddAttribute(4, "checked", checkbox.DefaultChecked);
                builder.AddAttribute(5, "disabled", true);
                builder.AddAttribute(6, "style", "width: 24px; height: 24px;");
                builder.CloseElement();

                builder.OpenElement(7, "span");
                builder.AddContent(8, checkbox.Label ?? "Checkbox");
                builder.CloseElement();

                builder.CloseElement();
                break;

            case ImageElement image:
                builder.OpenElement(0, "div");
                builder.AddAttribute(1, "style", style + " display: flex; align-items: center; justify-content: center; overflow: hidden;");

                if (!string.IsNullOrEmpty(image.ImageData))
                {
                    builder.OpenElement(2, "img");
                    builder.AddAttribute(3, "src", image.ImageData);
                    builder.AddAttribute(4, "alt", image.AltText);
                    builder.AddAttribute(5, "style", $"max-width: 100%; max-height: 100%; object-fit: {image.ObjectFit};");
                    builder.CloseElement();
                }
                else if (!string.IsNullOrEmpty(image.ImageUrl))
                {
                    builder.OpenElement(2, "img");
                    builder.AddAttribute(3, "src", image.ImageUrl);
                    builder.AddAttribute(4, "alt", image.AltText);
                    builder.AddAttribute(5, "style", $"max-width: 100%; max-height: 100%; object-fit: {image.ObjectFit};");
                    builder.CloseElement();
                }
                else
                {
                    builder.OpenElement(2, "div");
                    builder.AddAttribute(3, "style", "color: #999; text-align: center;");
                    builder.AddContent(4, "📷 Image Placeholder");
                    builder.CloseElement();
                }

                builder.CloseElement();
                break;

            default:
                builder.OpenElement(0, "div");
                builder.AddAttribute(1, "style", style);
                builder.AddContent(2, $"Unknown element type: {element.Type}");
                builder.CloseElement();
                break;
        }
    };
}
