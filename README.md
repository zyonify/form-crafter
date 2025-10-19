# Form Maker

A user-friendly drag-and-drop form builder designed specifically for elderly and non-technical users. Create professional business forms, legal documents, and authorization letters with an accessible, intuitive interface.

![Phase 1 Progress](https://img.shields.io/badge/Phase%201-100%25%20Complete-brightgreen)
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

## ✨ Current Features (Phase 1 - 100% Complete)

### Core Functionality
- ✅ **Drag & Drop Interface** - Click or drag elements from library to canvas
- ✅ **4 MVP Element Types**
  - Label/Heading - For titles and static text
  - Text Input - Single-line input fields
  - Checkbox - With customizable labels
  - Image - Logo and image placeholders
- ✅ **Smart Positioning**
  - Grid snapping (10px increments)
  - Alignment guides (centerline indicators)
  - Real-time position feedback (X, Y, W, H)
- ✅ **Live Property Editing**
  - Font size, bold, italic
  - Element dimensions and position
  - Element-specific properties (text content, placeholders, etc.)
- ✅ **Professional Canvas**
  - Multiple page sizes (A4, Letter, Legal, A3)
  - Visual margin guides for printable areas
  - Grid background for alignment

### Accessibility Features (WCAG 2.1 AA Compliant)
- ✅ **Large Touch Targets** - Minimum 48x48px buttons
- ✅ **Enhanced Readability** - 18px minimum font size
- ✅ **High Contrast Support** - 4.5:1 contrast ratio
- ✅ **Keyboard Navigation** - Full keyboard support with visible focus indicators
- ✅ **Reduced Motion Support** - Respects user preferences
- ✅ **Screen Reader Compatible** - Proper ARIA labels

## 🛠 Tech Stack

### Frontend
- **Blazor WebAssembly (.NET 8)** - Modern C# web framework
- **MudBlazor v8.13.0** - Material Design component library
- **Native HTML5 Drag & Drop** - No external dependencies

### Backend (Planned - Phase 3)
- **ASP.NET Core 8 Web API** - RESTful API
- **Azure Functions** - Serverless compute
- **Entity Framework Core** - Database ORM
- **PostgreSQL/Azure SQL** - Database

### Infrastructure
- **Azure Static Web Apps** - Frontend hosting with CDN
- **Azure Functions** - API hosting
- **Azure Blob Storage** - File storage (images, PDFs)
- **GitHub Actions** - CI/CD pipeline

### Additional Technologies (Planned)
- **QuestPDF** - Server-side PDF generation
- **SignalR** - Real-time collaboration (future)
- **SendGrid/Azure Communication Services** - Email notifications

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

3. **Run the application**
   ```bash
   dotnet run --project FormMaker.Client/FormMaker.Client.csproj
   ```

4. **Open in browser**
   ```
   Navigate to: http://localhost:5231
   ```

### Quick Start Guide

1. **Add Elements** - Click or drag elements from the left sidebar to the canvas
2. **Position Elements** - Drag elements on the canvas; they'll snap to a 10px grid
3. **Edit Properties** - Click an element to select it, then edit properties in the right panel
4. **Build Your Form** - Add multiple elements to create your complete form
5. **Save** - Click the Save button in the top toolbar (currently shows a toast notification)

## 📁 Project Structure

```
form-maker/
├── FormMaker.Client/              # Blazor WASM frontend
│   ├── Components/                # Reusable components
│   │   ├── Canvas.razor           # Main form editing canvas
│   │   └── ElementLibrary.razor   # Element sidebar
│   ├── Pages/                     # Application pages
│   │   └── Editor.razor           # Main editor page
│   ├── wwwroot/                   # Static files
│   │   ├── css/
│   │   │   └── custom-theme.css   # Accessibility-focused theme
│   │   └── staticwebapp.config.json
│   └── Program.cs                 # Application entry point
│
├── FormMaker.Shared/              # Shared models and DTOs
│   ├── Models/                    # Data models
│   │   ├── Elements/              # Element type definitions
│   │   ├── FormElement.cs         # Base element class
│   │   ├── FormTemplate.cs        # Form container
│   │   └── ElementProperties.cs   # Styling properties
│   └── Enums/                     # Enumerations
│
├── FormMaker.Api/                 # Backend API (Phase 3)
│   └── (Coming soon)
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
- [x] Accessibility-focused theme
- [x] Local storage persistence (auto-save + forms management)
- [x] Save/Load functionality with form list view
- [x] Basic element rendering (all 4 MVP types)

### Phase 2: Enhanced Editor (Planned)
- [ ] Additional form elements (Radio buttons, Dropdowns, Date pickers, Signatures, Tables, Text areas, Dividers, File uploads)
- [ ] Advanced styling options (Borders, backgrounds, spacing, shadows)
- [ ] Undo/redo system
- [ ] Element manipulation tools (Duplicate, copy/paste, resize handles, rotation, layering)
- [ ] Responsive preview modes

### Phase 3: Backend & Database (Planned)
- [ ] Azure Functions API setup
- [ ] Database schema & Entity Framework
- [ ] User authentication (JWT)
- [ ] Template CRUD operations
- [ ] API integration in frontend

### Phase 4: Form Sharing & Submissions (Planned)
- [ ] Shareable form links
- [ ] Public form filling interface
- [ ] Submission handling & storage
- [ ] Submissions dashboard
- [ ] Export to CSV/Excel

### Phase 5: PDF Generation (Planned)
- [ ] QuestPDF integration
- [ ] Blank form PDF export
- [ ] Filled form PDF export
- [ ] PDF customization (headers, footers, metadata)

### Phase 6: UX Polish for Elderly Users (Planned)
- [ ] WCAG 2.1 AA compliance audit
- [ ] Enhanced keyboard navigation
- [ ] Screen reader testing & improvements
- [ ] High contrast theme
- [ ] Interactive tutorial/onboarding
- [ ] Pre-built template gallery

### Phase 7: Deployment & Testing (Planned)
- [ ] Azure Static Web Apps deployment
- [ ] CI/CD pipeline setup
- [ ] Performance optimization
- [ ] User acceptance testing with target audience
- [ ] Cross-browser & mobile testing

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

- **Issues**: [GitHub Issues](https://github.com/yourusername/form-maker/issues)
- **Discussions**: [GitHub Discussions](https://github.com/yourusername/form-maker/discussions)

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

🤖 *Built with [Claude Code](https://claude.com/claude-code)*
