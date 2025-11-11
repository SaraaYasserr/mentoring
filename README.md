# Authentication Frontend Template
A simple and elegant login & signup interface for learning backend-frontend integration with C# .NET.

## 📋 Project Overview

This project provides a ready-to-use frontend template for authentication flows. It's designed to help backend developer understand how frontend applications communicate with backend APIs and to practice professional Git workflows.

## 🎯 Features

- **Login Page**: Username and password authentication
- **Signup Page**: Complete registration form with validation
- **Home Page**: Personalized welcome page after successful login
- **Client-side Validation**: Input validation before API calls
- **Error Handling**: Clear error messages for better UX
- **Responsive Design**: Works on all screen sizes
- **Loading Indicators**: Visual feedback during API calls

## 🚀 Getting Started

### Prerequisites
- A web browser (Chrome, Firefox, Edge, Safari)
- A C# backend API running on `http://localhost:8080` (You will implement this)
- Basic knowledge of Git

### Installation & Running

1. **Clone the Repository**
   ```bash
   git clone <repository-url>
   cd <repository-name>
   ```

2. **Open the Application**
   - use live server extension on vs code!

3. **Make Sure Your Backend is Running**
   - The frontend expects your C# API to be running on `http://localhost:8080`
   - Start your backend server before testing the frontend

## 🔌 API Integration

The frontend makes API calls to these endpoints:

### 1. Signup Endpoint
**URL:** `POST http://localhost:8080/api/auth/signup`

**Request Body:**
```json
{
  "name": "John Doe",
  "username": "johndoe",
  "email": "john@example.com",
  "password": "password123"
}
```

**Expected Success Response (200 OK):**
```json
{
  "message": "User created successfully",
  "userId": 1
}
```

**Expected Error Response (400 Bad Request):**
```json
{
  "message": "Username already exists",
  "field": "username"
}
```

### 2. Login Endpoint
**URL:** `POST http://localhost:8080/api/auth/login`

**Request Body:**
```json
{
  "username": "johndoe",
  "password": "password123"
}
```

**Expected Success Response (200 OK):**
```json
{
  "message": "Login successful",
  "username": "johndoe",
  "token": "optional-jwt-token"
}
```

**Expected Error Response (401 Unauthorized):**
```json
{
  "message": "Invalid credentials"
}
```

