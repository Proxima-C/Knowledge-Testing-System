import { Question } from "./question.model";

export interface Test {
    id: number;
    title: string;
    description: string;
    testDuration: number;
    testQuestionsIds: number[];
}