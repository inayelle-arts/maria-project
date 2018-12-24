import {TaskEntity} from "./TaskEntity";
import {EntityBase} from "./EntityBase";

export class ColumnEntity extends EntityBase
{
	private readonly _id: number;
	private _name: string;
	private readonly _tasks: TaskEntity[];
	
	constructor(id: number, name: string, tasks: TaskEntity[])
	{
		super();
		this._id = id;
		this._name = name;
		this._tasks = tasks;
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
	
	get tasks(): TaskEntity[]
	{
		return this._tasks;
	}
	
	save(): boolean
	{
		if (this._id === null)
		{
			return this.Manager.Column.add(this);
		} else
		{
			return this.Manager.Column.update(this);
		}
	}
}