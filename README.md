# PersonalFinanceManager

A powerful and modular Personal Finance Manager to help you track your income, expenses, and savings. This project is divided into multiple layers, each responsible for a specific part of the application.

## Solution Structure

The solution consists of the following projects:

- **PersonalFinance.API**: This is the API layer that exposes endpoints for interacting with the application. It handles HTTP requests and responses.
- **PersonalFinance.Business**: Contains the business logic for the application. This layer processes data from the API and the data access layer.
- **PersonalFinance.DataAccess**: Responsible for interacting with the database. This layer works with EF(Entity Framework) methods for querying and updating data.
- **PersonalFinance.Report**: This project handles generating financial reports, visualizations, and analytics.

## Features

- **Expense Tracking**: Track your daily expenses and categorize them.
- **Income Tracking**: Monitor your sources of income.
- **Budgeting**: Set and manage budgets for each category.
- **Reports & Analytics**: Generate and view financial reports, including visualizations.
- **Savings Goals**: Define and monitor savings goals.

## Technologies Used

- **Frontend**: HTML, CSS, JavaScript (React.js) (In Progress)
- **Backend**: ASP.NET Core Web API 
- **Database**: MS SQL Server 
