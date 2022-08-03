export interface Student {
  StudentId: number;
  Name: string;
}

export interface Lesson {
  Id: number;
  Name: string;
  Module: string;
}

export interface DetailStudent {
  StudentId: number;
  Name: string;
  TypeLicence: string;
  Identification: string;
  Age: number;
  Lessons: Lesson[];
}
