export interface Parameter {
  type: 'number' | 'date';
  title: string;
  value: any;
}

export interface Offer {
  title: string;
  description: string;
  parameters: Parameter[];
}

export const offers: Offer[] = [
  {
    title: 'personal_offers_by_average_check',
    description: 'Increase the average check',
    parameters: [
      {
        type: 'number',
        title: 'Average check calculation method (1 - per period, 2 - per quantity)',
        value: 1
      },
      {
        type: 'date',
        title: 'First date of the period (for method 1)',
        value: new Date('2010-01-01')
      },
      {
        type: 'date',
        title: 'Last date of the period (for method 1)',
        value: new Date('2022-12-31')
      },
      {
        type: 'number',
        title: 'Number of transactions (for method 2)',
        value: 100
      },
      {
        type: 'number',
        title: 'Coefficient of average check increase',
        value: 3
      },
      {
        type: 'number',
        title: 'Maximum churn index',
        value: 2
      },
      {
        type: 'number',
        title: 'Maximum share of transactions with a discount (in percent)',
        value: 1
      },
      {
        type: 'number',
        title: 'Allowable share of margin (in percent)',
        value: 10
      }
    ]
  },
  {
    title: 'personal_offers_by_frequency_of_visits',
    description: 'Increase the frequency of visits',
    parameters: [
      {
        type: 'date',
        title: 'First date of the period',
        value: new Date('2020-01-01')
      },
      {
        type: 'date',
        title: 'Last date of the period',
        value: new Date('2022-09-14')
      },
      {
        type: 'number',
        title: 'Added number of transactions',
        value: 10
      },
      {
        type: 'number',
        title: 'Maximum churn index',
        value: 20
      },
      {
        type: 'number',
        title: 'Maximum share of transactions with a discount (in percent)',
        value: 30
      },
      {
        type: 'number',
        title: 'Allowable margin share (in percent)',
        value: 40
      }
    ]
  },
  {
    title: 'cross_selling_offer',
    description: 'Cross-selling (margin growth)',
    parameters: [
      {
        type: 'number',
        title: 'Number of groups',
        value: 2
      },
      {
        type: 'number',
        title: 'Maximum churn index',
        value: 10
      },
      {
        type: 'number',
        title: 'Maximum consumption stability index',
        value: 2
      },
      {
        type: 'number',
        title: 'Maximum SKU share (in percent)',
        value: 2
      },
      {
        type: 'number',
        title: 'Allowable margin share (in percent)',
        value: 0.25
      }
    ]
  }
];
