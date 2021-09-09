import { Question } from "./question.model";

export interface Test {
    id: number;
    title: string;
    description: string;
    duration: TimeRanges;
    questions: Question[];
}
