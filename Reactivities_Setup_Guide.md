# Reactivities Project Setup Guide

This guide will walk you through setting up the Reactivities project, which uses **.NET** for the backend and **React** for the frontend. This guide assumes you are a beginner with these technologies.

## 1. Prerequisites

Before you start, you need to install the following software:

*   **Git:** For cloning the project from GitHub.
    *   Download from: [https://git-scm.com/downloads](https://git-scm.com/downloads)
*   **.NET SDK v9:** This is required for the backend.
    *   Download from: [https://dotnet.microsoft.com/download/dotnet/9.0](https://dotnet.microsoft.com/download/dotnet/9.0)
*   **Node.js (version 18+ or 20+):** This includes npm (Node Package Manager) and is required for the frontend.
    *   Download from: [https://nodejs.org/en/download](https://nodejs.org/en/download)

## 2. Clone the Project

Open your terminal or command prompt and run the following commands to clone the project and navigate into its directory:

```bash
git clone https://github.com/TryCatchLearn/Reactivities.git
cd Reactivities
```

## 3. Checkout a Specific Version (Optional but Recommended for Beginners)

The tutorial might be based on a specific commit. To ensure you are on the same version as the tutorial (which uses SQLite and no email confirmation by default), run:

```bash
git checkout 684e26a
```

## 4. Restore Project Dependencies

You need to install the required packages for both the backend and the frontend.

### Backend Dependencies (.NET)

Navigate to the `Reactivities` folder (if you are not already there) and run:

```bash
dotnet restore
```

### Frontend Dependencies (React)

Navigate into the `client` directory and install the Node.js packages:

```bash
cd client
npm install
```

## 5. Optional: Configure Cloudinary for Photo Uploads

If you want to enable photo upload functionality, you'll need a Cloudinary account (they offer a free tier).

1.  Go to [https://cloudinary.com/](https://cloudinary.com/) and sign up for a free account.
2.  Once logged in, find your Cloud Name, API Key, and API Secret on your dashboard.
3.  Create a new file named `appsettings.json` inside the `Reactivities/API` directory.
4.  Add the following content to `appsettings.json`, replacing the placeholder values with your actual Cloudinary credentials:

    ```json
    {
      "Cloudinary": {
        "CloudName": "YOUR_CLOUD_NAME",
        "ApiKey": "YOUR_API_KEY",
        "ApiSecret": "YOUR_API_SECRET"
      }
    }
    ```

## 6. Run the Application

You will need two separate terminal windows for this step: one for the backend and one for the frontend.

### Terminal 1: Start the Backend (.NET API)

Navigate to the `API` directory and run the .NET application:

```bash
cd API
dotnet run
```

You should see output indicating that the API is running, typically on `https://localhost:5000` or `https://localhost:5001`.

### Terminal 2: Start the Frontend (React App)

Open a **new** terminal window. Navigate to the `client` directory and start the React development server:

```bash
cd client
npm run dev
```

This will start the React application, usually on `http://localhost:3000`.

## 7. Access the Application

Once both the backend and frontend are running, open your web browser and go to:

```
https://localhost:3000
```

You can use the following test credentials to log in:

*   **Email:** `bob@test.com`
*   **Password:** `Pa$$w0rd`

Congratulations! You have successfully set up and run the Reactivities project.
