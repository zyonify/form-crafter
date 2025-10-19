# Form Crafter - Priority TODO List

## Phase 1: Testing & Quality (Current Focus)

### ✅ COMPLETED
- [x] Set up test project with xUnit, bUnit, Moq, FluentAssertions
- [x] Add unit tests for LocalStorageService (20+ tests)
- [x] Add unit tests for HistoryService (20+ tests)
- [x] Add unit tests for FormElement models (30+ tests)

### 🔴 HIGH PRIORITY - Immediate Fixes

#### 1. Fix 23 Failing Unit Tests
**Status:** IN PROGRESS
**Effort:** 1-2 hours
**Impact:** Critical - needed for CI/CD and code confidence

- [ ] Fix default value mismatches (colors: "#ffffff" vs "#FFFFFF")
- [ ] Fix nullable property assertions (MaxLength, MaxFileSize)
- [ ] Fix JSRuntime mock setup for LocalStorageService
- [ ] Verify all 71 tests pass
- [ ] Add test run to CI pipeline

#### 2. Advanced Styling UI (Phase 2.2)
**Status:** TODO
**Effort:** 4-6 hours
**Impact:** High - completes Phase 2 features

- [ ] Add border controls to Properties Panel (style, width, color, radius)
- [ ] Add background controls (color, opacity, gradient)
- [ ] Add shadow controls (box-shadow presets: none, small, medium, large)
- [ ] Add spacing controls (padding, margin with individual sides)
- [ ] Add opacity slider (0-100%)
- [ ] Live preview of style changes on canvas

#### 3. Form Validation Framework
**Status:** TODO
**Effort:** 6-8 hours
**Impact:** High - essential for production forms

- [ ] Create validation service/system
- [ ] Add required field validation
- [ ] Add input type validation (email, phone, URL, number ranges)
- [ ] Add custom validation rules support
- [ ] Add validation error display in preview mode
- [ ] Add form-level validation summary
- [ ] Unit tests for validation logic

#### 4. Accessibility Improvements (WCAG 2.1 AA)
**Status:** TODO
**Effort:** 8-10 hours
**Impact:** High - legal compliance & inclusive design

- [ ] Add ARIA labels to all canvas elements
- [ ] Add screen reader announcements for drag/drop actions
- [ ] Implement proper tab order management
- [ ] Add focus management for dialogs/modals
- [ ] Add alt text field to ImageElement
- [ ] Add keyboard shortcuts help dialog
- [ ] Run accessibility audit tools (axe, WAVE)
- [ ] Fix all WCAG AA violations

---

## Phase 2: Missing Phase 2 Features

### 🟡 MEDIUM PRIORITY

#### 5. Preview Mode (Phase 2.5)
**Status:** TODO
**Effort:** 4-6 hours
**Impact:** Medium - user testing essential

- [ ] Implement functional form preview (fillable fields)
- [ ] Add desktop preview mode
- [ ] Add tablet preview mode (768px)
- [ ] Add mobile preview mode (375px)
- [ ] Add print preview mode
- [ ] Add preview toolbar with device switcher

#### 6. Element Rotation (Phase 2.4)
**Status:** TODO
**Effort:** 3-4 hours
**Impact:** Medium - nice-to-have feature

- [ ] Add rotation handle to selected elements
- [ ] Add rotation angle input in Properties Panel
- [ ] Update CSS transform to include rotation
- [ ] Add rotation to undo/redo history
- [ ] Test rotation with resize handles

#### 7. Large Component Refactoring
**Status:** TODO
**Effort:** 10-12 hours
**Impact:** Medium - improves maintainability

- [ ] Break Canvas.razor.cs into smaller components
  - [ ] DragDropHandler component
  - [ ] ResizeHandler component
  - [ ] AlignmentGuides component
  - [ ] ElementRenderer (factory pattern)
- [ ] Replace switch statements with factory pattern
- [ ] Extract element rendering logic
- [ ] Add component-level unit tests

---

## Phase 3: New Features & Enhancements

### 🟢 LOW PRIORITY

#### 8. Multi-Page Form Support
**Status:** TODO
**Effort:** 8-10 hours
**Impact:** Low - future enhancement

- [ ] Add page management UI
- [ ] Add page navigation controls
- [ ] Support page breaks in forms
- [ ] Add page templates
- [ ] Test multi-page serialization

#### 9. Mobile Touch Support
**Status:** TODO
**Effort:** 6-8 hours
**Impact:** Low - mobile editing nice-to-have

- [ ] Add touch event handlers for drag/drop
- [ ] Optimize canvas for mobile viewports
- [ ] Add pinch-to-zoom for mobile
- [ ] Test on actual mobile devices

#### 10. Performance Optimization
**Status:** TODO
**Effort:** 8-10 hours
**Impact:** Low - optimize when needed

- [ ] Implement centralized state management (Fluxor or similar)
- [ ] Add debouncing to auto-save (currently 30s)
- [ ] Add virtual scrolling for element library
- [ ] Add memoization for expensive renders
- [ ] Load test with 100+ element forms
- [ ] Profile and optimize bottlenecks

---

## Phase 4: Backend Integration (Phase 3-7 from roadmap)

### ⚪ FUTURE WORK

#### 11. Backend API Setup
- [ ] Create ASP.NET Core Web API project
- [ ] Set up Entity Framework Core
- [ ] Create database schema (PostgreSQL/Azure SQL)
- [ ] Implement form CRUD endpoints
- [ ] Add authentication endpoints

#### 12. User Authentication
- [ ] Implement JWT authentication
- [ ] Add user registration/login
- [ ] Add password reset flow
- [ ] Implement role-based access control

#### 13. Form Sharing & Submissions
- [ ] Add public form links
- [ ] Implement form submission endpoint
- [ ] Create submission storage
- [ ] Add form response viewer

#### 14. PDF Export
- [ ] Research PDF generation libraries
- [ ] Implement form-to-PDF converter
- [ ] Add PDF download feature

#### 15. Azure Deployment
- [ ] Set up Azure Static Web Apps
- [ ] Configure Azure Functions
- [ ] Deploy database to Azure
- [ ] Set up CI/CD pipeline

---

## Current Sprint: Testing & Quality
**Goal:** Get to 100% test pass rate and fix immediate quality issues

**This Week:**
1. ✅ Fix 23 failing tests (Day 1)
2. ⬜ Add advanced styling UI (Day 2-3)
3. ⬜ Start validation framework (Day 4-5)

**Next Week:**
1. Complete validation framework
2. Accessibility improvements
3. Preview mode implementation

---

## Metrics & Goals

**Test Coverage:**
- Current: 71 tests, 48 passing (68%)
- Target: 71 tests, 71 passing (100%)
- Future: 150+ tests with component & E2E tests

**Code Quality:**
- Current: No linting, some large components
- Target: ESLint setup, max 300 lines per component

**Accessibility:**
- Current: Basic structure, missing ARIA
- Target: WCAG 2.1 AA compliant

**Performance:**
- Current: Not tested
- Target: Support 50+ elements with smooth UX

---

*Last Updated: 2025-10-19*
*Priority: 🔴 High | 🟡 Medium | 🟢 Low | ⚪ Future*
