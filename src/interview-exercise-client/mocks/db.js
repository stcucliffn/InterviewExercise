module.exports = () => {
  var faker = require('faker');
  faker.seed(1234); // Forces same original data

  const data = { accounts: [] };

  let accountHolder = faker.fake('{{name.firstName}} {{name.lastName}}');

  for (let i = 1; i <= 100; i++) {
    accountType = faker.finance.accountName();
    data.accounts.push({
      id: faker.random.uuid(),
      memberId: faker.random.number({ min: 1, max: 5 }),
      lastFour: faker.finance.mask(),
      type: accountType,
      nickname: accountType,
      accountHolder: accountHolder,
      balance: parseFloat(faker.finance.amount())
    });
  }

  return data;
};
