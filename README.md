# Garage Management System - Project Readme

## Overview

The Garage Management System is a project that demonstrates the implementation of object-oriented programming principles in C#, including classes, inheritance, and polymorphism. 
The system provides functionalities to manage a virtual garage, handling different types of vehicles such as regular motorcycles, electric motorcycles, regular cars, electric cars, and trucks.

## Goals

The primary goals of this project are as follows:

1. **Object-Oriented Programming:** The project showcases the effective use of classes, inheritance, and polymorphism to create a well-structured and maintainable codebase.

2. **Collections Usage:** The system employs collections like dictionaries and lists to efficiently manage and store vehicle-related data.

3. **Enums Implementation:** The project incorporates enums to represent various categories, such as license types and fuel types, ensuring a clear and structured data model.

4. **Dll (Assembly) Development:** The solution is organized into two projects, with one generating a DLL (assembly) containing the logical model of the system, promoting modularity and code reusability.

5. **Multiple Projects Management:** The system comprises two projects linked through references, maintaining a clear separation between the logical model and the console user interface.

6. **Exception Handling:** The project properly handles exceptions such as FormatException, ArgumentException, and ValueOutOfRangeException, ensuring robustness and smooth error handling.

## Functionality

The Garage Management System offers the following functionalities to the users:

1. **Add Vehicle:** Users can add new vehicles to the garage by providing relevant details based on the vehicle type (e.g., license number, fuel type, battery life, etc.).

2. **Display Vehicles:** The system displays a list of vehicles in the garage with the option to filter them based on their status (e.g., under repair, repaired, paid, etc.).

3. **Change Vehicle Status:** Users can change the status of a vehicle in the garage (e.g., from under repair to repaired) to track the vehicle's progress.

4. **Inflate Wheels:** The system allows users to inflate the wheels of a vehicle to their maximum pressure, ensuring optimal performance.

5. **Refuel Vehicles:** For fuel-operated vehicles, users can refuel with a specific fuel type and quantity, managing the fuel level accurately.

6. **Charge Electric Vehicles:** Users can charge electric vehicles' batteries for a specified number of minutes, ensuring they have sufficient power.

7. **Detailed Vehicle Information:** Users can view detailed information about a specific vehicle, such as license number, model, owner name, wheel details, fuel level, and battery status.

## Project Structure

The solution consists of two projects:

1. **Ex03.GarageLogic:** This project generates a DLL (assembly) containing the logical model of the Garage Management System. It includes classes for different vehicle types, wheel details, and garage management operations.

2. **Ex03.ConsoleUI:** This project implements the console-based user interface, allowing users to interact with the Garage Management System. It references the Ex03.GarageLogic project to utilize its functionalities.

## Installation and Usage

To run the Garage Management System:

1. Clone the repository to your local machine using the following command:

   ```
   git clone [https://github.com/your-username/garage-management.git](https://github.com/GuyBenja/Garage-management-system.git)
   ```

2. Open the solution file in Visual Studio or your preferred C# development environment.

3. Build the solution to ensure all dependencies are resolved and the projects are compiled.

4. Run the Ex03.ConsoleUI project to interact with the Garage Management System.

## Contribution and Support

Contributions, suggestions, and bug reports are welcome! Feel free to submit pull requests or open issues for any improvements or changes you'd like to propose.

If you encounter any issues or have questions related to the project, please create an issue in the repository.
