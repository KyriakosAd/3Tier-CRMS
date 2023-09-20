export class TeacherLecture {
    teacherId!: number;
    lectureId!: number;

    isValid(): boolean {
        const areNumbersValid = 
        this.teacherId > 0 && this.lectureId > 0;
    
        return areNumbersValid;
    }
}
