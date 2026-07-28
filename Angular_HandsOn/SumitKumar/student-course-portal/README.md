# Student Course Portal

A modern Angular application developed as part of the **Cognizant
Digital Nurture 5.0 -- Angular Hands-On** program. This repository
demonstrates Angular concepts through a series of hands-on exercises,
including routing, forms, services, HTTP communication, directives,
pipes, route guards, interceptors, NgRx state management, and unit
testing.

## Features

- Course listing and management
- Student enrollment forms
- Template-driven and Reactive Forms
- Custom directives and pipes
- HTTP services using HttpClient
- Route Guards
- HTTP Interceptors
- NgRx Store integration

## Tech Stack

- Angular 22
- TypeScript
- RxJS
- NgRx
- HTML & CSS
- Vitest (default testing framework in Angular 22)

## Hands-On Coverage

Hands-On Topic Status

---

1 Angular Fundamentals ✅
2 Components & Data Binding ✅
3 Routing ✅
4 Forms ✅
5 Services & Dependency Injection ✅
6 Directives & Pipes ✅
7 Route Guards ✅
8 HTTP Interceptors ✅
9 NgRx State Management ✅
10 Unit Testing ✅

## Project Structure

```text
src/
└── app/
    ├── components/
    ├── directives/
    ├── guards/
    ├── interceptors/
    ├── models/
    ├── pages/
    ├── pipes/
    ├── services/
    └── store/
```

## Getting Started

Clone the repository:

```bash
git clone <your-repository-url>
cd student-course-portal
```

Install dependencies:

```bash
npm install
```

Run the application:

```bash
ng serve
```

Run the unit tests:

```bash
ng test
```

## Unit Testing

As part of **Hands-On 10**, the following unit tests were implemented:

- `CourseCardComponent`
- `CourseService`
- `CourseList` (using NgRx MockStore)

Additional component `.spec.ts` files are the default Angular CLI
generated tests (`should create`) retained as part of the project
structure.

> **Note:** This project was created using **Angular CLI 22**, which
> uses **Vitest** as the default testing framework. The Hands-On guide
> references **Jasmine/Karma** (written for Angular v20), but the same
> Angular testing concepts---such as **TestBed**,
> **HttpTestingController**, and **MockStore**---have been implemented
> using Angular 22's default testing environment.

## Author

Sumit Kumar
