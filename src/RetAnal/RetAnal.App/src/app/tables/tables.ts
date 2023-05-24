export interface Table {
  columns: string[];
  rows: string[][];
  rowsAmount: number;
}

export interface Record {
  keys: string[];
  values: string[];
}

export const tables: string[] = [
  'cards',
  'checks',
  'groups_sku',
  'personal_data',
  'sku',
  'stores',
  'transactions'
];
