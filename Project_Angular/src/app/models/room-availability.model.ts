export class RoomAvailability {
    id: number | undefined;
    day!: number;
    startTime!: number;
    endTime!: number;
    roomId!: number;

    isValid(): boolean {
        const areNumbersValid = 
        this.day > 0 && this.startTime > 0 && this.endTime > 0 && this.roomId > 0;
        
        return areNumbersValid;
    }

    timeValid(): boolean {
        const isTimeValid =
        this.endTime > this.startTime;

        return isTimeValid;
    }
}
