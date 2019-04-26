export default class EvetId {
    
    private _id : number;
    private _name : string;
        
    public get id() : number {
        return this._id;    
    }

    public get name() : string {
        return this._name;
    }

    public constructor(id : number, name :string) {
        this._id = id;
        this._name = name;
    }

    public isEqual(eventId : EvetId) : boolean {
        return this._id === eventId._id;
    }
}