import {EntityBase} from "./EntityBase";

export class TaskEntity extends EntityBase
{
	private readonly _id: number;
	private _name: string;
	private _description: string;
	private readonly _code: string;
	
	constructor(id: number, name: string, description: string, code: string)
	{
		super();
		this._id = id;
		this._name = name;
		this._description = description;
		this._code = code;
	}
	
	public get Id() : number
	{
		return this._id;
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
	
	get description(): string
	{
		return this._description;
	}
	
	set description(value: string)
	{
		this._description = value;
	}
	
	get code(): string
	{
		return this._code;
	}
	
	public save(): boolean
	{
		throw new Error('not implemented');
	}
}
