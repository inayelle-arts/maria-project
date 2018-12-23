export class Task
{
	private _id: number;
	private _name: string;
	private _description: string;
	private _code: string;
	
	constructor(id: number, name: string, description: string, code: string)
	{
		this._id = id;
		this._name = name;
		this._description = description;
		this._code = code;
	}
	
	get name(): string
	{
		return this._name;
	}
	
	set name(value: string)
	{
		this._name = value;
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
	
	set code(value: string)
	{
		this._code = value;
	}
}
