import {ColumnEntity} from "./ColumnEntity";
import {EntityBase} from "./EntityBase";

export class BoardEntity extends EntityBase
{
	private readonly _id: number;
	private _name: string;
	private readonly _columns: ColumnEntity[];
	
	constructor(id: number, name: string, columns: ColumnEntity[])
	{
		super();
		this._id = id;
		this._name = name;
		this._columns = columns;
	}
	
	get Id() : number
	{
		return this._id;
	}
	
	get Columns(): ColumnEntity[]
	{
		return this._columns;
	}
	
	getName(): string
	{
		return this._name;
	}
	
	setName(value: string): boolean
	{
		const temp = this._name;
		this._name = value;
		
		if (!this.save())
		{
			this._name = temp;
			return false;
		}
		
		return true;
	}
	
	public save(): boolean
	{
		return this.Manager.Board.update(this);
	}
}