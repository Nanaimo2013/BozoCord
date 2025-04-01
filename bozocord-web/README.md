# BozoCord Web Client

This is the web client for BozoCord, built with React and TypeScript.

## Prerequisites

- Node.js (v14 or higher)
- npm (v6 or higher)
- BozoCord.Core running locally (or a deployed instance)

## Getting Started

1. Clone the repository
2. Navigate to the project directory:
   ```bash
   cd bozocord-web
   ```
3. Install dependencies:
   ```bash
   npm install
   ```
4. Start the development server:
   ```bash
   npm start
   ```

The application will be available at `http://localhost:3000`.

## Project Structure

```
src/
  ├── components/     # Reusable UI components
  ├── pages/         # Page components
  ├── services/      # API services
  └── App.tsx        # Main application component
```

## Features

- User authentication (login/register)
- Modern UI with Mantine components
- TypeScript for type safety
- React Query for data fetching
- React Router for navigation

## Development

- The application uses TypeScript for type safety
- Mantine UI components for the interface
- React Query for managing server state
- Axios for API communication

## Environment Variables

Create a `.env` file in the root directory with the following variables:

```
REACT_APP_API_URL=http://localhost:5000/api
```

## Contributing

1. Fork the repository
2. Create your feature branch
3. Commit your changes
4. Push to the branch
5. Create a new Pull Request 