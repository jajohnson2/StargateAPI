import { Person } from "./person";

export interface AstronautDuty {
  id: number;
  personId: number;
  currentRank: string;
  currentDutyTitle: string;
  careerStartDate: Date;
  careerEndDate: Date | null;
  person: Person;
}
