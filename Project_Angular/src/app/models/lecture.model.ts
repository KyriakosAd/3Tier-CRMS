export class Lecture {
    id: number | undefined;
    type!: string;
    courseId!: number;
    courseName!: string;
    semester!: number;
    department!: string;
    totalHours!: number;

    isValid(): boolean {
        const areStringsValid = 
        !!this.type && !!this.courseName && !!this.department;
    
        const areNumbersValid = 
        this.courseId > 0 && this.semester > 0 && this.totalHours > 0;
    
        return areNumbersValid && areStringsValid;
    }
}
