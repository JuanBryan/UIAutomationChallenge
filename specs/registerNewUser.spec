tags: UiTest
# Register a new Users
    This feature will contains all the scenarios relationed with the creation
    of new users; this will be use a generator of data.

## New user needs to be registered

tags: new user with random values

#### Test steps
* Given the user go to Home Page
* When  the user clicks on Sign in button
* And   the user fill in email address to create account
* And   the user clicks Create an account
* And   the user fill all fields with correct data
* And   the user clicks on Register Button
#### Assertions
* Then  the user verifies that the account page is displayed
* Then  the user verifies that the proper username is shown in the header
* Then  the user verifies that log out action is available
