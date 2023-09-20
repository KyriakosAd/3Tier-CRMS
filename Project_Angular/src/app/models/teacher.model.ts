export class Teacher {
    id: number | undefined;
    name!: string;
    type!: string;
    userId!: number;

    isValid(): boolean {
        const areStringsValid = 
        !!this.name && !!this.type;
    
        const areNumbersValid = 
        this.userId > 0;
    
        return areNumbersValid && areStringsValid;
    }
}
