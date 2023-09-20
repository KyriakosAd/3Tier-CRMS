export class Room {
    id: number | undefined;
    name!: string;
    building!: string;
    buildingAddress!: string;
    capacity!: number;
    type!: number;
    computersCount!: number;
    hasProjector!: boolean;
    isLocked!: boolean;

    isValid(): boolean {
        const areStringsValid = 
        !!this.name && !!this.building && !!this.buildingAddress;
    
        const areNumbersValid = 
        this.capacity > 0 && this.type > 0 && this.computersCount >= 0;
    
        return areNumbersValid && areStringsValid;
    }
}
