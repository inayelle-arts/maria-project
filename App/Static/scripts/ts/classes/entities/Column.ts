import {Task} from "./Task";

export class Column
{
	private readonly _id: number;
	private _name: string;
	private readonly _tasks: Task[];
	
	constructor(id: number, name: string, tasks: Task[])
	{
		this._id = id;
		this._name = name;
		this._tasks = tasks;
	}
	
	get name(): string
	{
		return this._name;
	}
	
	set name(value: string)
	{
		this._name = value;
	}
	
	get tasks(): Task[]
	{
		return this._tasks;
	}
}