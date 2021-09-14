import { Answer } from "./answer.model";

export interface Question {
    id: number;
    text: string;
    testId: number;
    answers: Answer[];
}