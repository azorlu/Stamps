import { KeyValuePair } from "./keyValuePair";

export interface Stamp {
  id: number;
  continent: KeyValuePair;
  country: KeyValuePair;
  category: KeyValuePair;
  yearIssued: number;
  title: string;
  description: string;
  lastUpdate: string;
}