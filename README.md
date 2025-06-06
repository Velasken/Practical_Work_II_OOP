# DDD
## Table of Contents
1. [Introduction](#introduction)
2. [Description](#description)
3. [Problems](#problems)
4. [Conclusions](#conclusions)

---

## Introduction

- **Summary**:
  - This document serves as a detailed design report for the Converter Calculator app. It covers the different functionalities of each page, the various problems encountered during development, and the conclusions reached after completing the project.

---

## Description
- **Login page (Main page)**: This page is responsible for checking if the introduced credentials correspond to any existing user within the users list. It is also the access point for the register page and the forget password page. This page is composed of two text labels, one for the username and another for the password, the register button which takes you to the register page, a forget password button which takes the user to the forget password page, and a submit button that, when pressed, starts a method to check if the user exists. If the user exists, it will automatically take the user to the conversor page. If not, a warning will pop up telling the user that the introduced credentials are wrong. It also includes an exit button that closes the app, but not before saving all the user’s data entered up to that moment.
- **Register Page**: This page includes four text labels: one for the username, another for the user email (which must be different from the username), another for the new password, and a final one for confirming the password (which must match the new password entry). It also has a privacy policy checkbox that must be checked for the user to register. When the submit button is pressed, it checks whether the entered data already corresponds to any existing user. It also verifies that the username and email are different, ensures that the new password and confirmation password match, confirms that all fields have been filled out, and that the privacy policy checkbox has been selected. Lastly, it checks whether the password is at least eight characters long and contains one uppercase letter, one lowercase letter, one number, and one special character. If all conditions are met, it creates the new user and adds them to the users list and the users CSV file. This page also has a back button that returns the user to the login page, and an exit button that functions the same as the one on the login page.
- **Forget Password Page**: This page is composed of three text labels: one to enter the username, another to enter the new password, and a last one to confirm the password (the new password and confirmation password fields must match). It also contains a submit button that, when pressed, checks whether the username exists so the password can be changed. It verifies that the new password and confirmation password fields have the same input, ensures the password meets the required criteria, and finally updates the user's password in both the users list and the users CSV file. This page also includes a back button that takes the user back to the login page, and an exit button.
- **Converter Page**: This is the most important page, as it is where all conversions are carried out. At the center of the interface is a text label that acts both as the input field for the conversion and the output display for the result. When the user presses any of the numeric buttons from 0 to 9, the corresponding digit is added to the text label. There is an “AC” button that, when pressed, completely clears the text label. The “-” button adds a minus sign to the input, which is especially useful for performing decimal to two’s complement binary conversions. The page also includes letter buttons labeled A through F, which are necessary for entering hexadecimal values.
The conversion buttons are tied to specific operations. When one of these buttons is pressed, the app takes the current input in the text label and attempts to convert it based on the chosen operation. If the input is valid, the result is displayed in the text label, the operation is logged into a CSV file, and the operation counter for the current user is increased by one. If the input is invalid for the selected operation, a pop-up message appears explaining the error. The text label is then cleared, and even in this case, the operation is saved and the user's operation count is still incremented.
There is an “Operations” button that takes the user to the operations page, saving the current operations file before transitioning. The “Logout” button returns the user to the login page, saving all of their data, including the number of operations performed. Finally, the “Exit” button performs the same data-saving steps as the logout button, but it also closes the application.
- **Operations Page**: This page is used to display all the user's information, including their username, email, password, and operation count. It contains three buttons. The "Converter" button takes the user to the converter page. The "Logout" button returns the user to the login page and saves all of their data. The "Exit" button performs the same function as the logout button, but it also closes the application.

![UML Diagram](./Files/UML_PWII.png)
---

## Problems
- **Challenges Faced**:
  - **Implementing the CSV File**: Integrating the CSV file for data took more time than expected because, in the beginning, I had designed the code to store users in lists. As a result, I had to modify the entire codebase to implement a method for adding users to the CSV file.
    - **Having more tha 1 user**: After creating the CSV file, I encountered an unexpected problem. When I created and logged in with one user, the user was correctly added to the CSV file. However, when I created a new user and logged in with them, their data overwrote the first user's data, changing the username, email, and password. Additionally, the operation count did not reset with the new user.
  - **Implementing the converter functions to the MAUI**: One of the biggest challenges I faced during the development of this project was integrating the functionalities of the pre-existing converter into my MAUI application.

---

## Conclusions
  - This project has been very helpful in emphasizing and deepening my knowledge of the MAUI environment, as well as in understanding how to implement console application code into functional apps with GUIs. It has allowed me to explore the structure and components of cross-platform development in a more practical context. Overall, this experience has significantly improved my confidence in building user-friendly applications using MAUI.
