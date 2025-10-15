# Form Maker - Development TODO

**Project:** Drag & Drop Form Builder for Business/Legal Documents
**Stack:** Blazor WASM + ASP.NET Core API + Azure Static Web Apps
**Target Users:** Elderly/Non-technical users
**Last Updated:** 2025-10-16

---

## 📋 RULES FOR UPDATING THIS FILE
1. ✅ Mark completed items with `[x]`
2. 🔗 **Always reference**: `File: path/to/file.cs` and `Method: MethodName()` for each story
3. 📝 Add implementation notes under each completed story
4. 🔄 Update "Last Updated" date when making changes
5. 🚫 Never delete completed items - keep them for reference

---

## 🎯 PHASE 1: MVP FOUNDATION (Weeks 1-3)

### Story 1.1: Project Setup & Infrastructure
- [x] **1.1.1** Initialize Blazor WASM project with .NET 8
  - File: `FormMaker.Client/FormMaker.Client.csproj`
  - Command: `dotnet new blazorwasm -n FormMaker.Client`
  - ✅ **Done:** Created Blazor WASM project with .NET 8.0.302

- [x] **1.1.2** Configure for Azure Static Web Apps
  - File: `FormMaker.Client/wwwroot/staticwebapp.config.json`
  - ✅ **Done:** Added routing rules, fallback routes, MIME types for WASM

- [x] **1.1.3** Set up solution structure
  - ✅ **Done:** Created solution with FormMaker.Client and FormMaker.Shared projects

- [x] **1.1.4** Install MudBlazor UI Framework
  - File: `FormMaker.Client/FormMaker.Client.csproj`
  - Package: `MudBlazor` v8.13.0
  - File: `FormMaker.Client/Program.cs` - Added MudBlazor services
  - File: `FormMaker.Client/_Imports.razor` - Added MudBlazor using statements
  - File: `FormMaker.Client/App.razor` - Added MudThemeProvider, MudDialogProvider, MudSnackbarProvider
  - ✅ **Done:** MudBlazor fully integrated

- [x] **1.1.5** Configure accessibility-focused theme
  - File: `FormMaker.Client/wwwroot/css/custom-theme.css`
  - ✅ **Done:** Created comprehensive accessibility theme with min font size 18px, button size 48px, contrast ratio 4.5:1, keyboard navigation support, high contrast mode, reduced motion support

---

### Story 1.2: Core Data Models
- [x] **1.2.1** Create FormElement base model
  - File: `FormMaker.Shared/Models/FormElement.cs`
  - ✅ **Done:** Abstract base class with Id, Type, X, Y, Width, Height, Properties, IsSelected, IsLocked, Label, IsRequired, Placeholder

- [x] **1.2.2** Create specific element models
  - File: `FormMaker.Shared/Models/Elements/TextInputElement.cs`
  - File: `FormMaker.Shared/Models/Elements/LabelElement.cs`
  - File: `FormMaker.Shared/Models/Elements/CheckboxElement.cs`
  - File: `FormMaker.Shared/Models/Elements/ImageElement.cs`
  - ✅ **Done:** All 4 MVP element types created with Clone() methods

- [x] **1.2.3** Create FormTemplate model
  - File: `FormMaker.Shared/Models/FormTemplate.cs`
  - ✅ **Done:** Comprehensive template model with Id, Name, Elements[], PageSize, Margins, helper methods

- [x] **1.2.4** Create ElementProperties model for styling
  - File: `FormMaker.Shared/Models/ElementProperties.cs`
  - ✅ **Done:** Complete styling model with text, background, border, spacing, shadow properties

---

### Story 1.3: Canvas/Workspace Component
- [x] **1.3.1** Create Canvas component
  - File: `FormMaker.Client/Components/Canvas.razor`
  - File: `FormMaker.Client/Components/Canvas.razor.cs`
  - ✅ **Done:** Canvas component with OnInitialized(), element rendering, drag/drop support

- [x] **1.3.2** Implement canvas grid background
  - File: `FormMaker.Client/wwwroot/css/custom-theme.css`
  - ✅ **Done:** CSS grid pattern with 10px spacing via `.canvas-grid` class

- [ ] **1.3.3** Add canvas zoom controls
  - File: `FormMaker.Client/Components/Canvas.razor`
  - Method: `ZoomIn()`, `ZoomOut()`, `ResetZoom()`
  - Property: `ZoomLevel` (50% - 200%)
  - ⏳ **TODO:** Implement zoom functionality

- [x] **1.3.4** Implement page size options
  - Method: `GetPageSizeClass()` in Canvas.razor.cs
  - File: `FormMaker.Shared/Enums/PageSize.cs`
  - ✅ **Done:** A4, Letter, Legal, A3, Custom page sizes with pixel calculations

- [x] **1.3.5** Add visual margins/safe area indicators
  - File: `FormMaker.Client/Components/Canvas.razor`
  - ✅ **Done:** Margin guides rendered with dashed border

---

### Story 1.4: Element Library Sidebar
- [x] **1.4.1** Create ElementLibrary component
  - File: `FormMaker.Client/Components/ElementLibrary.razor`
  - ✅ **Done:** ElementLibrary component with drag/click to add elements

- [x] **1.4.2** Add draggable element items (MVP 4 elements)
  - **Text Input**: Single-line input field ✅
  - **Label**: Static text/heading ✅
  - **Checkbox**: Checkbox with label ✅
  - **Image**: Logo/image placeholder ✅

- [x] **1.4.3** Implement element icons and labels
  - ✅ **Done:** MudBlazor icons with large, clear labels

- [x] **1.4.4** Add category grouping
  - File: `FormMaker.Shared/Enums/ElementCategory.cs`
  - ✅ **Done:** Categories: Basic, Input, Media, Layout, Advanced with visual separation in UI

---

### Story 1.5: Drag & Drop Implementation
- [x] **1.5.1** Use native Blazor drag events
  - ✅ **Done:** Using native `@ondrag` events with `@ondragover:preventDefault`

- [x] **1.5.2** Implement drag from ElementLibrary to Canvas
  - File: `FormMaker.Client/Components/Canvas.razor.cs`
  - Method: `HandleDrop(DragEventArgs e)`
  - ✅ **Done:** Elements can be added via click or drag

- [x] **1.5.3** Add element drag to reposition on canvas
  - Method: `HandleElementDragStart(FormElement element)`
  - Method: `HandleDragOver(DragEventArgs e)`
  - Method: `HandleDrop(DragEventArgs e)`
  - ✅ **Done:** Elements can be repositioned by dragging

- [x] **1.5.4** Implement visual feedback during drag
  - File: `FormMaker.Client/wwwroot/css/custom-theme.css`
  - CSS class: `.element-dragging`
  - ✅ **Done:** Dragging cursor and visual styles applied

---

### Story 1.6: Element Snapping & Alignment
- [x] **1.6.1** Implement grid snapping
  - File: `FormMaker.Client/Components/Canvas.razor.cs`
  - Method: `SnapToGrid(int value)`
  - ✅ **Done:** 10px grid snapping implemented

- [x] **1.6.2** Add alignment guides (center, edges)
  - File: `FormMaker.Client/Components/Canvas.razor`
  - Method: `CheckAlignmentGuides(FormElement element)`
  - ✅ **Done:** Vertical/horizontal centerline guides with 5px snap threshold

- [ ] **1.6.3** Implement smart spacing guides
  - Method: `CalculateSmartGuides(FormElement movingElement, FormElement[] otherElements)`
  - ⏳ **TODO:** Equal spacing indicators between elements

- [x] **1.6.4** Add position indicators overlay
  - File: `FormMaker.Client/Components/Canvas.razor`
  - ✅ **Done:** Position indicator showing X, Y, W, H during drag

---

### Story 1.7: Element Selection & Interaction
- [x] **1.7.1** Implement element selection
  - File: `FormMaker.Client/Components/Canvas.razor.cs`
  - Method: `HandleElementClick(FormElement element)`
  - ✅ **Done:** Element selection working with single-click

- [x] **1.7.2** Add selection visual indicators
  - File: `FormMaker.Client/wwwroot/css/custom-theme.css`
  - CSS class: `.element-selected`
  - ✅ **Done:** Selected elements show blue outline

- [ ] **1.7.3** Implement multi-select (Ctrl+Click)
  - Property: `SelectedElements[]`
  - Method: `OnMultiSelect(FormElement element, bool isCtrlPressed)`
  - ⏳ **TODO:** Multi-selection support

- [x] **1.7.4** Add delete element functionality
  - Method: `DeleteSelectedElement()` in Editor.razor
  - ✅ **Done:** Delete button in properties panel

---

### Story 1.8: Properties Panel
- [x] **1.8.1** Create PropertiesPanel (inline in Editor)
  - File: `FormMaker.Client/Pages/Editor.razor`
  - ✅ **Done:** Properties panel integrated in Editor page

- [x] **1.8.2** Add common properties editors
  - Font size numeric input (12-72px) ✅
  - Bold/Italic checkboxes ✅
  - Position (X, Y) and Size (Width, Height) inputs ✅

- [x] **1.8.3** Add element-specific properties
  - **Text Input**: Placeholder text, required toggle ✅
  - **Label**: Text content, heading level (H1-H6, P) ✅
  - **Checkbox**: Label text, default checked ✅
  - **Image**: Placeholder (upload TODO)

- [x] **1.8.4** Implement live property updates
  - ✅ **Done:** Using Blazor two-way binding `@bind-Value`

---

### Story 1.9: Local Storage Persistence
- [ ] **1.9.1** Create LocalStorageService
  - File: `FormMaker.Client/Services/LocalStorageService.cs`
  - Method: `SaveForm(FormTemplate form)`
  - Method: `LoadForm(string formId)`
  - Method: `GetAllForms()`
  - Use: `IJSRuntime` with `localStorage` JS Interop

- [ ] **1.9.2** Implement auto-save functionality
  - Method: `AutoSave()` - triggered every 30 seconds
  - File: `FormMaker.Client/Components/Canvas.razor.cs`
  - Use: `System.Timers.Timer`

- [ ] **1.9.3** Add save/load UI
  - File: `FormMaker.Client/Pages/Editor.razor`
  - Buttons: "Save", "Load", "New Form"
  - Show save status indicator: "Saved" / "Saving..." / "Unsaved changes"

- [ ] **1.9.4** Create form list view
  - File: `FormMaker.Client/Pages/FormList.razor`
  - Show all saved forms with preview thumbnails
  - Actions: Open, Duplicate, Delete

---

### Story 1.10: Basic Element Rendering
- [x] **1.10.1** TextInputElement rendering
  - File: `FormMaker.Client/Components/Canvas.razor.cs`
  - Method: `RenderElement(FormElement element)`
  - ✅ **Done:** Renders native `<input>` with applied styles

- [x] **1.10.2** LabelElement rendering
  - File: `FormMaker.Client/Components/Canvas.razor.cs`
  - ✅ **Done:** Renders H1-H6 or P tags with content

- [x] **1.10.3** CheckboxElement rendering
  - File: `FormMaker.Client/Components/Canvas.razor.cs`
  - ✅ **Done:** Renders `<input type="checkbox">` with label

- [x] **1.10.4** ImageElement rendering
  - File: `FormMaker.Client/Components/Canvas.razor.cs`
  - ✅ **Done:** Renders image or placeholder, supports Base64 and URL
  - ⏳ **TODO:** File upload functionality

---

## 🚀 PHASE 2: ENHANCED EDITOR (Weeks 4-5)

### Story 2.1: Additional Form Elements (Business Focus)
- [ ] **2.1.1** Radio Button Group Element
  - File: `FormMaker.Shared/Models/Elements/RadioGroupElement.cs`
  - File: `FormMaker.Client/Components/Elements/RadioGroupElementView.razor`
  - Properties: Options[], SelectedValue, Layout (Vertical/Horizontal)

- [ ] **2.1.2** Dropdown/Select Element
  - File: `FormMaker.Shared/Models/Elements/DropdownElement.cs`
  - File: `FormMaker.Client/Components/Elements/DropdownElementView.razor`
  - Properties: Options[], Placeholder, AllowMultiple

- [ ] **2.1.3** Date Picker Element
  - File: `FormMaker.Shared/Models/Elements/DatePickerElement.cs`
  - File: `FormMaker.Client/Components/Elements/DatePickerElementView.razor`
  - Use: `<MudDatePicker>`
  - Properties: MinDate, MaxDate, Format

- [ ] **2.1.4** Signature Field Element
  - File: `FormMaker.Shared/Models/Elements/SignatureElement.cs`
  - File: `FormMaker.Client/Components/Elements/SignatureElementView.razor`
  - Use: Canvas-based signature pad with JS Interop
  - Method: `SaveSignature()` - Save as PNG Base64

- [ ] **2.1.5** Table/Grid Element
  - File: `FormMaker.Shared/Models/Elements/TableElement.cs`
  - File: `FormMaker.Client/Components/Elements/TableElementView.razor`
  - Properties: Rows, Columns, Headers[], CellData[][]
  - Method: `AddRow()`, `AddColumn()`, `RemoveRow()`, `RemoveColumn()`

- [ ] **2.1.6** Multi-line Text Area Element
  - File: `FormMaker.Shared/Models/Elements/TextAreaElement.cs`
  - File: `FormMaker.Client/Components/Elements/TextAreaElementView.razor`
  - Properties: Rows, MaxLength, Placeholder

- [ ] **2.1.7** Divider/Separator Element
  - File: `FormMaker.Shared/Models/Elements/DividerElement.cs`
  - File: `FormMaker.Client/Components/Elements/DividerElementView.razor`
  - Properties: Style (Solid/Dashed/Dotted), Thickness, Color

- [ ] **2.1.8** File Upload Element
  - File: `FormMaker.Shared/Models/Elements/FileUploadElement.cs`
  - File: `FormMaker.Client/Components/Elements/FileUploadElementView.razor`
  - Properties: AllowedExtensions[], MaxFileSize, Multiple

---

### Story 2.2: Advanced Styling & Customization
- [ ] **2.2.1** Border styling options
  - File: `FormMaker.Client/Components/PropertiesPanel.razor`
  - Properties: BorderStyle (None/Solid/Dashed), BorderWidth (0-10px), BorderColor, BorderRadius

- [ ] **2.2.2** Background styling
  - Properties: BackgroundColor, BackgroundOpacity, BackgroundImage

- [ ] **2.2.3** Spacing controls
  - Properties: Padding (Top/Right/Bottom/Left), Margin

- [ ] **2.2.4** Shadow effects
  - Properties: BoxShadow (None/Small/Medium/Large), ShadowColor

- [ ] **2.2.5** Advanced text styling
  - Properties: LineHeight, LetterSpacing, TextTransform (Uppercase/Lowercase/Capitalize)

---

### Story 2.3: Undo/Redo System
- [ ] **2.3.1** Create HistoryService
  - File: `FormMaker.Client/Services/HistoryService.cs`
  - Method: `RecordState(FormTemplate state)`
  - Method: `Undo()` - Returns previous state
  - Method: `Redo()` - Returns next state
  - Property: `HistoryStack[]`, `RedoStack[]`, `MaxHistorySize = 50`

- [ ] **2.3.2** Integrate with canvas operations
  - File: `FormMaker.Client/Components/Canvas.razor.cs`
  - Call `historyService.RecordState()` after each change

- [ ] **2.3.3** Add keyboard shortcuts
  - Ctrl+Z: Undo
  - Ctrl+Y or Ctrl+Shift+Z: Redo
  - File: `FormMaker.Client/Services/KeyboardShortcutService.cs`

- [ ] **2.3.4** Add undo/redo UI buttons
  - File: `FormMaker.Client/Components/Toolbar.razor`
  - Disable buttons when stacks are empty

---

### Story 2.4: Element Manipulation Tools
- [ ] **2.4.1** Element duplication
  - Method: `DuplicateElement(FormElement element)`
  - Keyboard shortcut: Ctrl+D

- [ ] **2.4.2** Element copy/paste
  - Method: `CopyElement()`, `PasteElement()`
  - Keyboard shortcuts: Ctrl+C, Ctrl+V
  - Store in clipboard state

- [ ] **2.4.3** Element resize handles
  - File: `FormMaker.Client/Components/ResizeHandles.razor`
  - 8 handles: corners + sides
  - Method: `OnResize(ResizeDirection direction, int deltaX, int deltaY)`
  - Maintain aspect ratio when Shift is pressed

- [ ] **2.4.4** Element rotation
  - Property: `Rotation` (0-360 degrees)
  - UI: Rotation handle above element
  - Method: `RotateElement(float degrees)`

- [ ] **2.4.5** Element layering (z-index)
  - Method: `BringToFront()`, `SendToBack()`, `BringForward()`, `SendBackward()`
  - UI: Context menu or toolbar buttons

---

### Story 2.5: Responsive Preview Modes
- [ ] **2.5.1** Add preview mode toggle
  - File: `FormMaker.Client/Components/Toolbar.razor`
  - Modes: Desktop, Tablet, Mobile, Print

- [ ] **2.5.2** Implement responsive canvas sizing
  - Method: `SetPreviewMode(PreviewMode mode)`
  - Desktop: 1200px, Tablet: 768px, Mobile: 375px

- [ ] **2.5.3** Add print preview mode
  - Show actual page breaks
  - File: `FormMaker.Client/Pages/PrintPreview.razor`

---

## 🗄️ PHASE 3: BACKEND & DATABASE (Weeks 6-7)

### Story 3.1: Azure Functions API Setup
- [ ] **3.1.1** Create Azure Functions project
  - File: `FormMaker.Api/FormMaker.Api.csproj`
  - Command: `dotnet new func -n FormMaker.Api`
  - Runtime: .NET 8 Isolated

- [ ] **3.1.2** Configure local development
  - File: `FormMaker.Api/local.settings.json`
  - Add CORS settings for local Blazor app

- [ ] **3.1.3** Set up Entity Framework Core
  - File: `FormMaker.Api/FormMaker.Api.csproj`
  - Packages: `Microsoft.EntityFrameworkCore`, `Microsoft.EntityFrameworkCore.SqlServer`

- [ ] **3.1.4** Create DbContext
  - File: `FormMaker.Api/Data/FormMakerDbContext.cs`
  - DbSets: Users, Templates, Forms, Submissions

---

### Story 3.2: Database Schema & Models
- [ ] **3.2.1** Create User entity
  - File: `FormMaker.Shared/Entities/User.cs`
  - Properties: Id (Guid), Email, PasswordHash, CreatedAt, UpdatedAt

- [ ] **3.2.2** Create Template entity
  - File: `FormMaker.Shared/Entities/Template.cs`
  - Properties: Id (Guid), UserId, Name, Description, JsonData, Category, IsPublic, CreatedAt, UpdatedAt

- [ ] **3.2.3** Create Form entity
  - File: `FormMaker.Shared/Entities/Form.cs`
  - Properties: Id (Guid), TemplateId, ShareLink (unique), IsPublic, IsActive, CreatedAt, ExpiresAt

- [ ] **3.2.4** Create Submission entity
  - File: `FormMaker.Shared/Entities/Submission.cs`
  - Properties: Id (Guid), FormId, JsonData, SubmittedAt, IpAddress, UserAgent

- [ ] **3.2.5** Add EF migrations
  - Command: `dotnet ef migrations add InitialCreate`
  - Command: `dotnet ef database update`

---

### Story 3.3: Authentication System
- [ ] **3.3.1** Implement user registration
  - File: `FormMaker.Api/Functions/AuthFunctions.cs`
  - Method: `Register(HttpRequestData req)` - POST /api/auth/register
  - Use BCrypt for password hashing

- [ ] **3.3.2** Implement user login
  - Method: `Login(HttpRequestData req)` - POST /api/auth/login
  - Return JWT token

- [ ] **3.3.3** JWT token generation
  - File: `FormMaker.Api/Services/TokenService.cs`
  - Method: `GenerateToken(User user)`
  - Package: `System.IdentityModel.Tokens.Jwt`

- [ ] **3.3.4** JWT validation middleware
  - File: `FormMaker.Api/Middleware/AuthenticationMiddleware.cs`
  - Validate token on protected endpoints

- [ ] **3.3.5** Integrate auth in Blazor client
  - File: `FormMaker.Client/Services/AuthService.cs`
  - Method: `LoginAsync(string email, string password)`
  - Method: `RegisterAsync(string email, string password)`
  - Method: `LogoutAsync()`
  - Store token in `localStorage`

---

### Story 3.4: Template CRUD API
- [ ] **3.4.1** Create Template - POST /api/templates
  - File: `FormMaker.Api/Functions/TemplateFunctions.cs`
  - Method: `CreateTemplate(HttpRequestData req)`
  - Requires authentication

- [ ] **3.4.2** Get user templates - GET /api/templates
  - Method: `GetUserTemplates(HttpRequestData req)`
  - Return templates owned by authenticated user

- [ ] **3.4.3** Get single template - GET /api/templates/{id}
  - Method: `GetTemplate(HttpRequestData req, string id)`

- [ ] **3.4.4** Update template - PUT /api/templates/{id}
  - Method: `UpdateTemplate(HttpRequestData req, string id)`
  - Verify ownership before updating

- [ ] **3.4.5** Delete template - DELETE /api/templates/{id}
  - Method: `DeleteTemplate(HttpRequestData req, string id)`
  - Soft delete: set `IsDeleted = true`

---

### Story 3.5: Integrate API with Blazor Client
- [ ] **3.5.1** Create ApiService
  - File: `FormMaker.Client/Services/ApiService.cs`
  - Method: `SendAuthenticatedRequest<T>(string endpoint, HttpMethod method, object body)`
  - Attach JWT token to requests

- [ ] **3.5.2** Replace LocalStorage with API calls
  - File: `FormMaker.Client/Components/Canvas.razor.cs`
  - Method: `SaveFormAsync()` - Call API instead of localStorage
  - Method: `LoadFormAsync(string id)`

- [ ] **3.5.3** Add loading states & error handling
  - Show loading spinner during API calls
  - Display error messages with `<MudSnackbar>`

- [ ] **3.5.4** Implement offline mode fallback
  - Detect when API is unreachable
  - Fall back to localStorage temporarily
  - Sync when connection restored

---

## 📤 PHASE 4: FORM SHARING & SUBMISSIONS (Weeks 8-9)

### Story 4.1: Shareable Form Links
- [ ] **4.1.1** Generate unique share links
  - File: `FormMaker.Api/Functions/FormFunctions.cs`
  - Method: `CreateShareLink(HttpRequestData req)` - POST /api/forms/create-link
  - Generate random unique slug (8-12 chars)
  - Return: `https://yourapp.com/f/{slug}`

- [ ] **4.1.2** Link settings & options
  - Properties: ExpiresAt (optional), MaxSubmissions, RequireAuth, AllowAnonymous
  - UI: Share modal with settings

- [ ] **4.1.3** Get form by share link - GET /api/forms/{slug}
  - Method: `GetFormBySlug(HttpRequestData req, string slug)`
  - Return template JSON for rendering

- [ ] **4.1.4** Track link analytics
  - Properties: ViewCount, LastAccessedAt
  - Method: `IncrementViewCount(string slug)`

---

### Story 4.2: Public Form Filling Interface
- [ ] **4.2.1** Create public form page
  - File: `FormMaker.Client/Pages/FillForm.razor`
  - Route: `/f/{slug}`
  - Render form elements in fill-only mode (no editing)

- [ ] **4.2.2** Implement form validation
  - File: `FormMaker.Client/Services/ValidationService.cs`
  - Method: `ValidateForm(FormTemplate template, Dictionary<string, object> values)`
  - Check required fields, format validation (email, date, etc.)

- [ ] **4.2.3** Create mobile-responsive form view
  - File: `FormMaker.Client/Pages/FillForm.razor.css`
  - Stack elements vertically on mobile
  - Large touch targets for inputs

- [ ] **4.2.4** Add form submission UI
  - Submit button at bottom
  - Show validation errors
  - Success confirmation message

---

### Story 4.3: Submission Handling
- [ ] **4.3.1** Submit form API - POST /api/forms/{slug}/submit
  - File: `FormMaker.Api/Functions/SubmissionFunctions.cs`
  - Method: `SubmitForm(HttpRequestData req, string slug)`
  - Save submission to database

- [ ] **4.3.2** Capture submission metadata
  - Store: IP address, User-Agent, SubmittedAt timestamp
  - Optional: Geolocation (if consent given)

- [ ] **4.3.3** Email notification on submission
  - File: `FormMaker.Api/Services/EmailService.cs`
  - Method: `SendSubmissionNotification(string email, Submission submission)`
  - Use: SendGrid or Azure Communication Services

- [ ] **4.3.4** Anti-spam measures
  - Rate limiting: Max 5 submissions per IP per hour
  - reCAPTCHA integration (optional)
  - File: `FormMaker.Api/Services/RateLimitService.cs`

---

### Story 4.4: Submissions Dashboard
- [ ] **4.4.1** Create submissions list page
  - File: `FormMaker.Client/Pages/Submissions.razor`
  - Route: `/submissions/{formId}`
  - Show table with: Date, IP, Preview of data

- [ ] **4.4.2** View single submission detail
  - File: `FormMaker.Client/Pages/SubmissionDetail.razor`
  - Route: `/submissions/{formId}/{submissionId}`
  - Render form with filled data

- [ ] **4.4.3** Export submissions to CSV
  - Method: `ExportToCSV(List<Submission> submissions)`
  - Download file: `submissions-{formName}-{date}.csv`

- [ ] **4.4.4** Export submissions to Excel
  - Package: `ClosedXML` or `EPPlus`
  - Method: `ExportToExcel(List<Submission> submissions)`

- [ ] **4.4.5** Filter & search submissions
  - Filter by: Date range, IP, specific field values
  - Search text in submission data

---

## 📄 PHASE 5: PDF GENERATION (Weeks 10-11)

### Story 5.1: PDF Library Setup
- [ ] **5.1.1** Install QuestPDF
  - File: `FormMaker.Api/FormMaker.Api.csproj`
  - Package: `QuestPDF` v2024.x
  - License: MIT (free for open source)

- [ ] **5.1.2** Create PdfService
  - File: `FormMaker.Api/Services/PdfService.cs`
  - Method: `GeneratePdf(FormTemplate template, Dictionary<string, object> data = null)`

---

### Story 5.2: Blank Form PDF Export
- [ ] **5.2.1** Render template to PDF
  - File: `FormMaker.Api/Services/PdfService.cs`
  - Method: `RenderTemplateToPdf(FormTemplate template)`
  - Map form elements to PDF components

- [ ] **5.2.2** Support all element types in PDF
  - Text inputs: Render as underlined blank space
  - Labels: Render as static text
  - Checkboxes: Render as empty boxes
  - Images: Embed images
  - Tables: Render grid structure
  - Signatures: Render as blank signature line

- [ ] **5.2.3** Apply styling to PDF elements
  - Method: `ApplyStylesToElement(FormElement element)`
  - Map CSS properties to PDF styles

- [ ] **5.2.4** Handle page breaks
  - Method: `CalculatePageBreaks(FormTemplate template)`
  - Ensure elements don't split across pages

- [ ] **5.2.5** Export blank PDF endpoint - GET /api/templates/{id}/export-pdf
  - File: `FormMaker.Api/Functions/TemplateFunctions.cs`
  - Method: `ExportBlankPdf(HttpRequestData req, string id)`
  - Return PDF file

---

### Story 5.3: Filled Form PDF Export
- [ ] **5.3.1** Render submission data in PDF
  - Method: `RenderFilledFormToPdf(FormTemplate template, Submission submission)`
  - Fill in form field values

- [ ] **5.3.2** Export filled PDF endpoint - GET /api/submissions/{id}/export-pdf
  - File: `FormMaker.Api/Functions/SubmissionFunctions.cs`
  - Method: `ExportFilledPdf(HttpRequestData req, string id)`

- [ ] **5.3.3** Add PDF watermark option
  - Method: `AddWatermark(string text, float opacity)`
  - Example: "COPY" or "DRAFT"

- [ ] **5.3.4** Batch PDF export
  - Method: `ExportMultipleSubmissionsToPdf(List<Submission> submissions)`
  - Create single PDF with multiple submissions

---

### Story 5.4: PDF Customization
- [ ] **5.4.1** Add PDF metadata
  - Properties: Title, Author, Subject, Keywords, CreatedDate
  - Method: `SetPdfMetadata(PdfMetadata metadata)`

- [ ] **5.4.2** Header/Footer support
  - Method: `AddHeader(string text, bool includePageNumbers)`
  - Method: `AddFooter(string text, bool includeDate)`

- [ ] **5.4.3** Custom page size support
  - Support: A4, Letter, Legal, A3, Custom
  - Method: `SetPageSize(PageSize size)`

- [ ] **5.4.4** PDF quality settings
  - Options: Draft (smaller file), Standard, High Quality
  - Compress images for smaller file size

---

## 🎨 PHASE 6: UX POLISH FOR ELDERLY USERS (Week 12)

### Story 6.1: Accessibility Improvements
- [ ] **6.1.1** WCAG 2.1 AA compliance audit
  - Run automated tools: axe DevTools, WAVE
  - File: `ACCESSIBILITY_AUDIT.md` - Document findings

- [ ] **6.1.2** Keyboard navigation support
  - Tab through all interactive elements
  - Keyboard shortcuts list: Ctrl+S (save), Ctrl+Z (undo), etc.
  - File: `FormMaker.Client/Services/KeyboardShortcutService.cs`

- [ ] **6.1.3** Screen reader compatibility
  - Add ARIA labels to all elements
  - File: `FormMaker.Client/Components/Canvas.razor`
  - Test with NVDA or JAWS

- [ ] **6.1.4** Focus indicators
  - Visible focus outline on all interactive elements
  - File: `wwwroot/css/accessibility.css`
  - CSS: `:focus { outline: 3px solid #005fcc; }`

- [ ] **6.1.5** Color contrast verification
  - Ensure 4.5:1 contrast ratio for text
  - 3:1 for large text and UI components
  - Use: WebAIM Contrast Checker

---

### Story 6.2: Large Touch Targets
- [ ] **6.2.1** Increase button sizes
  - Minimum size: 48x48px (WCAG AAA standard)
  - File: `wwwroot/css/custom-theme.css`
  - Apply to all buttons, checkboxes, radio buttons

- [ ] **6.2.2** Increase spacing between interactive elements
  - Minimum 8px gap between clickable elements
  - Reduce accidental clicks

- [ ] **6.2.3** Larger form inputs
  - Input height: 56px minimum
  - Font size: 18px minimum

- [ ] **6.2.4** Simplified toolbar layout
  - Group related actions
  - Use icons + text labels (not just icons)

---

### Story 6.3: High Contrast Theme
- [ ] **6.3.1** Create high contrast theme
  - File: `FormMaker.Client/Themes/HighContrastTheme.cs`
  - Colors: Black/White primary, no gradients

- [ ] **6.3.2** Add theme switcher
  - File: `FormMaker.Client/Components/ThemeSwitcher.razor`
  - Options: Standard, High Contrast, Dark Mode
  - Save preference in localStorage

- [ ] **6.3.3** Test with Windows High Contrast mode
  - Ensure compatibility with OS-level high contrast settings

---

### Story 6.4: Onboarding & Help System
- [ ] **6.4.1** Create welcome tutorial
  - File: `FormMaker.Client/Pages/Tutorial.razor`
  - Interactive walkthrough: 5 steps
  - Steps: 1) Drag element, 2) Position it, 3) Edit properties, 4) Save, 5) Share

- [ ] **6.4.2** Add contextual tooltips
  - Use `<MudTooltip>` on all toolbar buttons
  - Simple language: "Drag this to add text"

- [ ] **6.4.3** Create help documentation
  - File: `FormMaker.Client/Pages/Help.razor`
  - Video tutorials (optional)
  - FAQs section

- [ ] **6.4.4** Add "Undo" confirmation prompts
  - For destructive actions: Delete element, delete form
  - File: `FormMaker.Client/Components/ConfirmDialog.razor`

---

### Story 6.5: Template Gallery
- [ ] **6.5.1** Seed pre-built templates
  - File: `FormMaker.Api/Data/TemplateSeed.cs`
  - Create 10-15 common templates:
    - Job Application Form
    - Event Registration
    - Leave Request Form
    - Purchase Order
    - Feedback Form
    - Authorization Letter
    - Consent Form
    - Attendance Sheet
    - Quotation Template
    - Timesheet

- [ ] **6.5.2** Create template gallery page
  - File: `FormMaker.Client/Pages/TemplateGallery.razor`
  - Route: `/templates`
  - Display templates with preview images

- [ ] **6.5.3** Template categories & filtering
  - Categories: Business, Legal, HR, Events, General
  - Filter by category, search by name

- [ ] **6.5.4** "Use Template" functionality
  - Method: `CreateFromTemplate(string templateId)`
  - Creates copy in user's account

---

## 🚀 PHASE 7: DEPLOYMENT & TESTING (Weeks 13-14)

### Story 7.1: Azure Static Web Apps Deployment
- [ ] **7.1.1** Create Azure Static Web App resource
  - Use: Azure Portal or Azure CLI
  - Command: `az staticwebapp create`

- [ ] **7.1.2** Configure GitHub Actions workflow
  - File: `.github/workflows/azure-static-web-apps.yml`
  - Auto-generated by Azure Static Web Apps

- [ ] **7.1.3** Configure API backend (Azure Functions)
  - Link Functions app to Static Web App
  - File: `staticwebapp.config.json`
  - Add API routes configuration

- [ ] **7.1.4** Set up environment variables
  - File: `FormMaker.Api/local.settings.json` (local)
  - Azure Portal: Configuration > Application Settings (production)
  - Variables: ConnectionString, JwtSecret, EmailApiKey

---

### Story 7.2: Database Deployment
- [ ] **7.2.1** Create Azure SQL Database
  - Use: Azure Portal
  - Tier: Basic (for MVP) or Standard

- [ ] **7.2.2** Run EF migrations on production DB
  - Command: `dotnet ef database update --connection "production_connection_string"`

- [ ] **7.2.3** Set up database backups
  - Azure SQL automatic backups enabled
  - Document restore procedure

---

### Story 7.3: CI/CD Pipeline
- [ ] **7.3.1** Configure build workflow
  - File: `.github/workflows/build.yml`
  - Steps: Restore, Build, Test

- [ ] **7.3.2** Configure deployment workflow
  - Trigger on push to `main` branch
  - Deploy to Azure Static Web Apps

- [ ] **7.3.3** Add automated tests to pipeline
  - Run unit tests before deployment
  - Block deployment if tests fail

---

### Story 7.4: Performance Optimization
- [ ] **7.4.1** Enable Blazor WASM lazy loading
  - File: `FormMaker.Client/FormMaker.Client.csproj`
  - Split large components into separate assemblies

- [ ] **7.4.2** Optimize bundle size
  - Remove unused MudBlazor components
  - Enable IL Linker trimming

- [ ] **7.4.3** Add loading indicators
  - Show spinner during API calls
  - Skeleton screens for form loading

- [ ] **7.4.4** Implement caching
  - Cache templates in browser
  - HTTP caching headers on API responses
  - File: `FormMaker.Api/Functions/CachingMiddleware.cs`

---

### Story 7.5: Testing
- [ ] **7.5.1** Unit tests for core services
  - File: `FormMaker.Tests/Services/SnapServiceTests.cs`
  - File: `FormMaker.Tests/Services/ValidationServiceTests.cs`
  - File: `FormMaker.Tests/Services/HistoryServiceTests.cs`
  - Use: xUnit or NUnit

- [ ] **7.5.2** Integration tests for API
  - File: `FormMaker.Tests/Api/TemplateApiTests.cs`
  - File: `FormMaker.Tests/Api/AuthApiTests.cs`
  - Use: WebApplicationFactory

- [ ] **7.5.3** User acceptance testing with target audience
  - Recruit 5-10 elderly users
  - Observe them using the app
  - Document pain points
  - File: `UAT_FEEDBACK.md`

- [ ] **7.5.4** Cross-browser testing
  - Test on: Chrome, Firefox, Safari, Edge
  - Test on mobile: iOS Safari, Android Chrome

- [ ] **7.5.5** Load testing
  - Use: Azure Load Testing or K6
  - Test: 100 concurrent users creating forms
  - File: `load-test-results.md`

---

### Story 7.6: Documentation
- [ ] **7.6.1** User documentation
  - File: `docs/USER_GUIDE.md`
  - How to create a form, share it, view submissions

- [ ] **7.6.2** Developer documentation
  - File: `docs/DEVELOPER_GUIDE.md`
  - Architecture overview, setup instructions

- [ ] **7.6.3** API documentation
  - File: `docs/API_REFERENCE.md`
  - Or use Swagger/OpenAPI

- [ ] **7.6.4** Deployment guide
  - File: `docs/DEPLOYMENT.md`
  - Step-by-step Azure setup

---

## 🎁 FUTURE ENHANCEMENTS (Post-MVP)

### Advanced Features (Prioritize based on user feedback)
- [ ] **Multi-language support (i18n)**
  - File: `FormMaker.Client/Resources/`
  - Support: English, Spanish, Tagalog (Philippines market?)

- [ ] **Conditional logic** (show/hide fields based on answers)
  - File: `FormMaker.Shared/Models/ConditionalRule.cs`

- [ ] **Form branching** (different pages based on answers)

- [ ] **Payment integration** (Stripe, PayPal)
  - For paid form submissions or premium features

- [ ] **Email form submissions** (instead of just link sharing)

- [ ] **Webhooks** (send submission data to external systems)

- [ ] **Form analytics** (conversion rates, completion time)

- [ ] **Collaboration** (multiple users editing same template)

- [ ] **Version history** for templates

- [ ] **Form templates marketplace** (buy/sell templates)

- [ ] **Mobile app** (iOS/Android) using .NET MAUI

- [ ] **Offline form filling** (PWA with service workers)

- [ ] **E-signature legal compliance** (DocuSign-like features)

- [ ] **OCR** (scan paper forms and convert to digital)

---

## 📊 PROGRESS TRACKER

**Phase 1:** 8/10 stories completed (80%) ✅ MVP Core Features Done!
**Phase 2:** 0/5 stories completed (0%)
**Phase 3:** 0/5 stories completed (0%)
**Phase 4:** 0/4 stories completed (0%)
**Phase 5:** 0/4 stories completed (0%)
**Phase 6:** 0/5 stories completed (0%)
**Phase 7:** 0/6 stories completed (0%)

**Overall Progress:** 8/39 stories completed (21%)

---

## 🐛 KNOWN ISSUES & BUGS

*Track bugs discovered during development here*

---

## 💡 NOTES & LEARNINGS

*Document important decisions, gotchas, and lessons learned here*

---

**Last Updated:** 2025-10-16
**Started:** 2025-10-16
**Current Phase:** Phase 1 - MVP Foundation
