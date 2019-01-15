# Interview Exercise
====================

🔬Sample Angular and ASP.Net Core application to use as a foundation for interview exercises


## Web API Requirements

- Create the ability to retrieve the list of accounts for a member given a member id which contains:
  Id, LastFour (of account number), Nickname, Type and Balance.
- Filter the list of accounts to active accounts and for accounts without a nickname provide a
  default nickname of "Savings" for saving accounts and "Checking" for checking accounts.
- Include the additional property AccountHolder in the list of accounts. The AccountHolder should be
  the first and last name of the member.
- Create the ability to retrieve a single account given an account id which contains: Id, LastFour,
  Nickname, Type, Balance and AccountHolder.
- Create the ability to update the Nickname of an account given an account id.


Repository Symbols
------------------

- 🏢 internal app
- 🌎 external app
- ⚙️ automated job or service
- 📚 library
- 🛂 requires SSO from online banking (or other integration)
- 📛 requires a client certificate
- 🔓 no authentication required
- 💽️ includes a database project
- 🔒 stores sensitive data that requires encryption
- 💳 uses credit card data (subject to PCI-DSS/ISO27001/SAS70)
- 🔬 experimental
- 🏚️ deprecated or unmaintained
- 🌶️ spicy
