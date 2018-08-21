module.exports = () => {
  var faker = require('faker');
  faker.seed(1234); // Forces same original data

  const data = { accounts: [] };

  let accountHolder = faker.fake('{{name.firstName}} {{name.lastName}}');

  for (let i = 1; i <= 10; i++) {
    data.accounts.push({
      id: faker.random.uuid(),
      lastFour: faker.finance.mask(),
      type: faker.finance.accountName(),
      accountHolder: accountHolder,
      balance: parseFloat(faker.finance.amount())
    });
  }

  return data;
};
