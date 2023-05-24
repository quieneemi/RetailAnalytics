import {Table} from "./tables";

function generateCsv(table: Table): string {
  const data: string[][] = [...table.rows];
  data.unshift(table.columns);

  let csv: string = '';
  for (let i = 0; i < data.length; i++) {
    for (let j = 0; j < data[i].length; j++) {
      let cellData = data[i][j];
      let csvCell = cellData.replace(/"/g, '""');
      csv += `"${csvCell}"`;
      if (j < data[i].length - 1) {
        csv += ',';
      }
    }
    csv += '\n';
  }

  return csv;
}

export const exportToCsv = (table: Table, tableName: string): void => {
  const csv = generateCsv(table);
  const link = document.createElement('a');
  link.href = 'data:text/csv;charset=utf-8,' + encodeURIComponent(csv);
  link.download = tableName + '.csv';
  link.click();
};
