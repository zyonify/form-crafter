using FormMaker.Shared.Enums;
using System.Text.Json.Serialization;

namespace FormMaker.Shared.Models;

/// <summary>
/// A complete form template containing all elements and settings
/// </summary>
public class FormTemplate
{
    /// <summary>
    /// Unique identifier for the template
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Name of the form template
    /// </summary>
    public string Name { get; set; } = "Untitled Form";

    /// <summary>
    /// Optional description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// All elements in the form
    /// </summary>
    public List<FormElement> Elements { get; set; } = new();

    /// <summary>
    /// Page size for the form
    /// </summary>
    public PageSize PageSize { get; set; } = PageSize.Letter;

    /// <summary>
    /// Custom width if PageSize is Custom (in pixels)
    /// </summary>
    public int? CustomWidth { get; set; }

    /// <summary>
    /// Custom height if PageSize is Custom (in pixels)
    /// </summary>
    public int? CustomHeight { get; set; }

    /// <summary>
    /// Margin sizes (in pixels)
    /// </summary>
    public int MarginTop { get; set; } = 48; // 0.5 inch
    public int MarginRight { get; set; } = 48;
    public int MarginBottom { get; set; } = 48;
    public int MarginLeft { get; set; } = 48;

    /// <summary>
    /// Background color of the form
    /// </summary>
    public string BackgroundColor { get; set; } = "#ffffff";

    /// <summary>
    /// Category for organization
    /// </summary>
    public string? Category { get; set; }

    /// <summary>
    /// Tags for searchability
    /// </summary>
    public List<string> Tags { get; set; } = new();

    /// <summary>
    /// When the template was created
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// When the template was last updated
    /// </summary>
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Version number for tracking changes
    /// </summary>
    public int Version { get; set; } = 1;

    /// <summary>
    /// Whether this is a public template (in template gallery)
    /// </summary>
    public bool IsPublic { get; set; } = false;

    /// <summary>
    /// Gets the actual width in pixels based on PageSize
    /// </summary>
    [JsonIgnore]
    public int WidthInPixels
    {
        get
        {
            return PageSize switch
            {
                PageSize.A4 => 794, // 210mm at 96 DPI
                PageSize.Letter => 816, // 8.5in at 96 DPI
                PageSize.Legal => 816, // 8.5in at 96 DPI
                PageSize.A3 => 1123, // 297mm at 96 DPI
                PageSize.Custom => CustomWidth ?? 816,
                _ => 816
            };
        }
    }

    /// <summary>
    /// Gets the actual height in pixels based on PageSize
    /// </summary>
    [JsonIgnore]
    public int HeightInPixels
    {
        get
        {
            return PageSize switch
            {
                PageSize.A4 => 1123, // 297mm at 96 DPI
                PageSize.Letter => 1056, // 11in at 96 DPI
                PageSize.Legal => 1344, // 14in at 96 DPI
                PageSize.A3 => 1587, // 420mm at 96 DPI
                PageSize.Custom => CustomHeight ?? 1056,
                _ => 1056
            };
        }
    }

    /// <summary>
    /// Adds an element to the form
    /// </summary>
    public void AddElement(FormElement element)
    {
        Elements.Add(element);
        UpdatedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Removes an element from the form
    /// </summary>
    public bool RemoveElement(Guid elementId)
    {
        var element = Elements.FirstOrDefault(e => e.Id == elementId);
        if (element != null)
        {
            Elements.Remove(element);
            UpdatedAt = DateTime.UtcNow;
            return true;
        }
        return false;
    }

    /// <summary>
    /// Gets an element by ID
    /// </summary>
    public FormElement? GetElement(Guid elementId)
    {
        return Elements.FirstOrDefault(e => e.Id == elementId);
    }

    /// <summary>
    /// Clears all selected elements
    /// </summary>
    public void ClearSelection()
    {
        foreach (var element in Elements)
        {
            element.IsSelected = false;
        }
    }

    /// <summary>
    /// Gets all currently selected elements
    /// </summary>
    public List<FormElement> GetSelectedElements()
    {
        return Elements.Where(e => e.IsSelected).ToList();
    }

    /// <summary>
    /// Updates the timestamp
    /// </summary>
    public void MarkAsUpdated()
    {
        UpdatedAt = DateTime.UtcNow;
    }
}
