# Form Maker

A user-friendly drag-and-drop form builder designed specifically for elderly and non-technical users. Create professional business forms, legal documents, and authorization letters with an accessible, intuitive interface.

![Phase 1-3 Progress](https://img.shields.io/badge/Phase%201--3-Complete-brightgreen)
![Phase 4 Progress](https://img.shields.io/badge/Phase%204-In%20Progress-yellow)
![.NET](https://img.shields.io/badge/.NET-8.0-512BD4)
![Blazor](https://img.shields.io/badge/Blazor-WASM-5C2D91)
![License](https://img.shields.io/badge/license-MIT-blue)

## 🎯 Project Vision

Form Maker bridges the gap between powerful form creation tools and users who need simplicity. Whether it's creating a job application, authorization letter, or attendance sheet, Form Maker makes it accessible to everyone—especially those who find traditional software overwhelming.

### Target Users
- **Elderly users** who need to create professional documents
- **Small business owners** without technical expertise
- **HR departments** creating repetitive forms
- **Community organizations** needing printable and digital forms

## ✨ Current Features (Phases 1-3 Complete)

### Core Functionality
- ✅ **Drag & Drop Interface** - Click or drag elements from library to canvas
- ✅ **12 Element Types**
  - Label/Heading - For titles and static text
  - Text Input - Single-line input fields
  - Text Area - Multi-line text input
  - Checkbox - With customizable labels
  - Radio Group - Multiple choice selection
  - Dropdown - Select from options list
  - Date Picker - Date selection with calendar
  - File Upload - File input with validation
  - Image - Logo and image placeholders with upload
  - Signature - Canvas-based signature capture
  - Table - Dynamic rows and columns
  - Divider - Visual separators
- ✅ **Smart Positioning**
  - Grid snapping (10px increments)
  - Alignment guides (centerline indicators)
  - Smart spacing indicators
  - Real-time position feedback (X, Y, W, H)
- ✅ **Advanced Property Editing**
  - Font size, bold, italic, text color
  - Element dimensions and position
  - Borders (style, width, color, radius)
  - Background colors and opacity
  - Spacing (padding, margin)
  - Shadow effects
  - Element rotation
  - Element-specific properties
- ✅ **Professional Canvas**
  - Multiple page sizes (A4, Letter, Legal, A3, Custom)
  - Visual margin guides for printable areas
  - Grid background for alignment
  - Zoom controls (50%-200%)
- ✅ **Editing Tools**
  - Undo/Redo with keyboard shortcuts
  - Copy/Paste/Duplicate elements
  - Multi-select with Ctrl+Click
  - Element layering (bring to front, send to back)
  - Resize handles
  - Delete with confirmation

### Accessibility Features (WCAG 2.1 AA Compliant)
- ✅ **Large Touch Targets** - Minimum 48x48px buttons
- ✅ **Enhanced Readability** - 18px minimum font size
- ✅ **High Contrast Support** - 4.5:1 contrast ratio
- ✅ **Keyboard Navigation** - Full keyboard support with shortcuts (Ctrl+Z/Y, Ctrl+C/V/D, Ctrl+A)
- ✅ **Reduced Motion Support** - Respects user preferences
- ✅ **Screen Reader Compatible** - Proper ARIA labels and semantic HTML
- ✅ **Automated Testing** - axe-core integration for continuous accessibility audits

### Backend & Database
- ✅ **User Authentication** - JWT-based auth with register/login
- ✅ **Cloud Storage** - Forms saved to database, accessible from any device
- ✅ **API Integration** - RESTful API with full CRUD operations
- ✅ **Auto-save** - Forms automatically saved every 30 seconds
- ✅ **Form Sharing** - Generate shareable links for form submissions

### Export & Preview
- ✅ **PDF Export** - Export blank or filled forms to PDF (all 12 element types)
- ✅ **Responsive Preview** - Desktop, tablet, and mobile preview modes
- ✅ **Form Validation** - Built-in validation framework for required fields and input types

## 🛠 Tech Stack

### Frontend
- **Blazor WebAssembly (.NET 8)** - Modern C# web framework
- **MudBlazor v8.13.0** - Material Design component library
- **Native HTML5 Drag & Drop** - No external dependencies

### Backend (Deployed)
- **ASP.NET Core 8 Minimal API** - RESTful API deployed to Render.com
- **Entity Framework Core 8** - Database ORM with migrations
- **SQLite** - Lightweight embedded database
- **JWT Authentication** - Secure token-based auth

### Infrastructure
- **GitHub Pages** - Frontend hosting at https://zyonify.github.io/form-crafter/
- **Render.com** - API hosting at https://form-crafter.onrender.com/api/
- **GitHub Actions** - Automated CI/CD with test runner and deployment

### Additional Technologies
- **jsPDF** - Client-side PDF generation
- **axe-core** - Automated accessibility testing
- **xUnit + bUnit** - Unit testing framework (120+ tests)
- **Moq** - Mocking framework for API tests

## 🚀 Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- A modern web browser (Chrome, Firefox, Edge, Safari)
- Git

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/yourusername/form-maker.git
   cd form-maker
   ```

2. **Restore dependencies**
   ```bash
   dotnet restore
   ```

3. **Run the API (optional - use live API by default)**
   ```bash
   cd FormMaker.Api
   dotnet run
   ```

4. **Run the application**
   ```bash
   dotnet run --project FormMaker.Client/FormMaker.Client.csproj
   ```

5. **Open in browser**
   ```
   Navigate to: http://localhost:5231
   ```

### Live Demo
- **Frontend**: https://zyonify.github.io/form-crafter/
- **API**: https://form-crafter.onrender.com/api/

### Quick Start Guide

1. **Register/Login** - Create an account to save your forms to the cloud
2. **Add Elements** - Click or drag elements from the left sidebar to the canvas
3. **Position Elements** - Drag elements on the canvas; they'll snap to a 10px grid
4. **Edit Properties** - Click an element to select it, then edit properties in the right panel
5. **Build Your Form** - Add multiple elements to create your complete form
6. **Save** - Forms auto-save every 30 seconds, or click Save button manually
7. **Share** - Click Share to generate a public link for form submissions
8. **Export PDF** - Export your form as a PDF for printing or distribution

## 📁 Project Structure

```
form-maker/
├── FormMaker.Client/              # Blazor WASM frontend
│   ├── Components/                # Reusable components
│   │   ├── Canvas.razor           # Main form editing canvas
│   │   ├── ElementLibrary.razor   # Element sidebar
│   │   ├── PageTabs.razor         # Multi-page support
│   │   └── ShareFormDialog.razor  # Form sharing UI
│   ├── Pages/                     # Application pages
│   │   ├── Editor.razor           # Main editor page
│   │   ├── Forms.razor            # Form management page
│   │   ├── PreviewMode.razor      # Responsive preview
│   │   └── Auth/                  # Login/Register pages
│   ├── Services/                  # Business logic
│   │   ├── ApiService.cs          # API client
│   │   ├── HistoryService.cs      # Undo/redo
│   │   ├── ValidationService.cs   # Form validation
│   │   └── PdfExportService.cs    # PDF generation
│   ├── wwwroot/                   # Static files
│   │   ├── css/custom-theme.css   # Accessibility theme
│   │   └── js/                    # JavaScript interop
│   └── Program.cs                 # Application entry point
│
├── FormMaker.Shared/              # Shared models and DTOs
│   ├── Models/                    # Data models
│   │   ├── Elements/              # 12 element types
│   │   ├── FormElement.cs         # Base element class
│   │   ├── FormTemplate.cs        # Form container
│   │   ├── TemplateModels.cs      # API DTOs
│   │   └── ElementProperties.cs   # Styling properties
│   └── Enums/                     # Enumerations
│
├── FormMaker.Api/                 # ASP.NET Core API
│   ├── Functions/                 # API endpoints
│   │   ├── AuthFunctions.cs       # Authentication
│   │   ├── TemplateFunctions.cs   # Form CRUD
│   │   ├── FormFunctions.cs       # Form sharing
│   │   └── SubmissionFunctions.cs # Form submissions
│   ├── Services/                  # Business logic
│   ├── Data/                      # EF Core DbContext
│   └── Migrations/                # Database migrations
│
├── FormMaker.Tests/               # Test suite
│   ├── Services/                  # Service tests (120+ tests)
│   ├── Models/                    # Model tests
│   └── Api/                       # Integration tests
│
├── TODO.md                        # Detailed development roadmap
└── README.md                      # This file
```

## 🗺 Development Roadmap

### Phase 1: MVP Foundation (100% Complete) ✅
- [x] Project setup with Blazor WASM + MudBlazor
- [x] Core data models (FormElement, FormTemplate, ElementProperties)
- [x] Canvas component with drag & drop
- [x] Element library sidebar
- [x] Grid snapping & alignment guides
- [x] Element selection & properties panel
- [x] 4 MVP element types
- [x] Accessibility-focused theme (WCAG 2.1 AA compliant)
- [x] Save/Load functionality with form list view
- [x] Basic element rendering (all MVP types)

### Phase 2: Enhanced Editor (100% Complete) ✅
- [x] Additional form elements (8 new types: TextArea, Dropdown, DatePicker, Signature, Table, RadioGroup, FileUpload, Divider)
- [x] Advanced styling options (Borders, backgrounds, spacing, shadows, rotation)
- [x] Undo/redo system with keyboard shortcuts
- [x] Element manipulation tools (Duplicate, copy/paste, resize handles, rotation, layering)
- [x] Responsive preview modes (Desktop, Tablet, Mobile)
- [x] Multi-page form support
- [x] Image upload functionality

### Phase 2.6: Testing & Quality (100% Complete) ✅
- [x] Unit testing infrastructure (120+ tests with xUnit, bUnit, Moq)
- [x] Form validation framework (34 validation tests)
- [x] Accessibility improvements (WCAG 2.1 AA compliance)
- [x] Bug fixes (9 critical/high/medium bugs resolved)
- [x] CI/CD pipeline (GitHub Actions with automated testing)

### Phase 3: Backend & Database (95% Complete) ✅
- [x] ASP.NET Core API deployed to Render.com
- [x] Database with SQLite + EF Core migrations
- [x] User authentication (JWT tokens, register/login)
- [x] Template CRUD operations (Create, Read, Update, Delete)
- [x] API integration in frontend (Forms.razor, Editor.razor)
- [x] Auto-save to database every 30 seconds
- [x] Comprehensive API tests (15 unit + 8 integration tests)

### Phase 4: Form Sharing & Submissions (40% Complete) 🚧
- [x] Shareable form links generation
- [x] Share dialog UI with notification settings
- [x] Form entity and database schema
- [ ] Public form filling interface
- [ ] Submission handling & storage
- [ ] Submissions dashboard
- [ ] Export to CSV/Excel

### Phase 5: PDF Generation (80% Complete) ✅
- [x] jsPDF integration (client-side)
- [x] Blank form PDF export (all 12 element types)
- [x] Filled form PDF export infrastructure
- [x] PDF customization (metadata, page sizes)
- [ ] PDF watermarks (optional)
- [ ] Batch PDF export (optional)

### Phase 6: UX Polish for Elderly Users (Partial)
- [x] WCAG 2.1 AA compliance audit with axe-core
- [x] Enhanced keyboard navigation with shortcuts
- [x] Screen reader compatibility with ARIA labels
- [ ] High contrast theme (standard theme is high-contrast)
- [ ] Interactive tutorial/onboarding
- [ ] Pre-built template gallery

### Phase 7: Deployment & Testing (90% Complete) ✅
- [x] GitHub Pages deployment (frontend)
- [x] Render.com deployment (API)
- [x] CI/CD pipeline with GitHub Actions
- [x] Automated testing (120+ unit tests)
- [x] Cross-browser testing
- [ ] Performance optimization (deferred)
- [ ] User acceptance testing with target audience
- [ ] Mobile device testing

## 🎨 Design Principles

### Accessibility First
Every design decision prioritizes accessibility:
- **Large text and buttons** for easy reading and clicking
- **Clear visual feedback** for all interactions
- **Simple language** in tooltips and instructions
- **Keyboard-friendly** for users who can't use a mouse
- **High contrast** options for visual impairments

### Progressive Disclosure
Complex features are hidden initially, revealed only when needed:
- Basic elements shown first
- Advanced styling options progressively introduced
- Tooltips provide contextual help

### Forgiving Design
Mistakes are easy to fix:
- Undo/redo for all actions (coming in Phase 2)
- Confirmation prompts for destructive actions
- Auto-save to prevent data loss (coming in Phase 1)

## 📝 Use Cases

### Business Forms
- Job application forms
- Event registration forms
- Leave request forms
- Purchase orders
- Feedback/evaluation forms
- Attendance sheets
- Timesheets
- Quotation templates

### Legal Documents
- Letters of authorization
- Consent forms
- Non-disclosure agreements (NDAs)
- Acknowledgment receipts
- Waivers/liability releases
- Simple affidavits
- Certificate templates

## 🤝 Contributing

Contributions are welcome! This project is designed to help non-technical users, so contributions that improve accessibility and ease-of-use are especially valued.

### Development Guidelines
1. Follow WCAG 2.1 AA accessibility standards
2. Maintain minimum 18px font sizes
3. Ensure touch targets are at least 48x48px
4. Test with keyboard navigation
5. Use clear, simple language in UI text

### Getting Started
1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (follow the commit message format in git log)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## 📄 License

This project is licensed under the MIT License - see the LICENSE file for details.

## 🙏 Acknowledgments

- **MudBlazor** - Excellent Blazor component library
- **Blazor Team** - For the amazing framework
- **Target Users** - Elderly and non-technical users whose needs inspired this project

## 📞 Support & Feedback

- **Issues**: [GitHub Issues](https://github.com/zyonify/form-crafter/issues)
- **Discussions**: [GitHub Discussions](https://github.com/zyonify/form-crafter/discussions)
- **Live Demo**: https://zyonify.github.io/form-crafter/

## 🔮 Future Vision

Form Maker aims to become the go-to solution for creating accessible, professional forms without technical knowledge. Future enhancements include:

- **Multi-language support** - Reach users worldwide
- **Conditional logic** - Smart forms that adapt to user input
- **Collaboration features** - Multiple users editing together
- **Mobile app** - Native iOS/Android apps using .NET MAUI
- **Template marketplace** - Community-contributed templates
- **Offline mode** - Progressive Web App capabilities
- **E-signature integration** - Legal compliance for digital signatures
- **OCR capabilities** - Scan paper forms and convert to digital

---

**Made with ❤️ for users who deserve accessible, user-friendly software**
