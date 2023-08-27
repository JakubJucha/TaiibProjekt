export class Events {
    constructor(
    public id: number = -1,
    public eventName?: string,
    public location?: string,
    public date?: string,
    public description?: string, 
    public category?: string,
    public amountTicket?: string,
    public ticketPrice?: string,
    public sponsors?: string[]
    ){}
}