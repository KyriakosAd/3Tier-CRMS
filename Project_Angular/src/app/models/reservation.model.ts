export class Reservation {
    id: number | undefined;
    entryDate!: Date;
    isRecurring!: boolean;
    startDate!: Date;
    endDate!: Date;
    exactDate!: Date;
    day!: number;
    startTime!: number;
    endTime!: number;
    roomId!: number;

    isValid(): boolean {
        const areDatesValid = 
        !!this.startDate && !!this.endDate && !!this.exactDate;
    
        const areNumbersValid =
        this.isRecurring ? (this.day > 0 && this.startTime > 0 && this.endTime > 0) : (this.startTime > 0 && this.endTime > 0);
    
        return areNumbersValid && areDatesValid;
    }

    timeValid(): boolean {
        const isTimeValid =
        this.endTime > this.startTime;

        return isTimeValid;
    }

    dateValid(): boolean {
        const isDateValid =
        this.isRecurring ? (this.endDate > this.startDate) : (true);

        return isDateValid;
    }
}
