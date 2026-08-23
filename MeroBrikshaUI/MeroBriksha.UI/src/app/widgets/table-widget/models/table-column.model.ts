export interface TableColumn {
  key: string;
  label: string;
  type: ColumnType;
  config?: ColumnConfig;
}

export interface ColumnConfig {
  actions?: TableAction[];
}

export interface TableAction {
  label: string;
  type: ActionType; 
  routerLink?: (row: any) => any[]; //Angular's routerLink directive can accept an array of route segments:<a [routerLink]="['/campaigns', 42, 'edit']">Edit</a>
  disabled?: (row: any) => boolean;
  onClick?: (row: any) => void;
}
export enum ColumnType {
  text,
  number,
  actions,
  routerLink
}
export enum ActionType {
  link,
  button
}
