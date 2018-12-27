import {TaskEntity} from "./TaskEntity";
import {EntityBase} from "./EntityBase";
import {JsonObject, JsonProperty} from "json2typescript";
import {ResponseResultSet} from "../repos/ResponseResultSet";

@JsonObject("ColumnEntity")
export class ColumnEntity extends EntityBase
{
	@JsonProperty("id", Number)
	private _id: number;
	
	@JsonProperty("name", String)
	private _name: string;
	
	@JsonProperty("tasks", [TaskEntity])
	private _tasks: Array<TaskEntity>;
	
	// constructor(id: number, name: string, tasks: TaskEntity[])
	// {
	// 	super();
	// 	this._id = id;
	// 	this._name = name;
	// 	this._tasks = tasks;
	// }
	
	get id(): number
	{
		return this._id;
	}
	
	set id(value: number)
	{
		this._id = value;
	}
	
	get name(): string
	{
		return this._name;
	}
	
	set name(value: string)
	{
		this._name = value;
	}
	
	get tasks(): Array<TaskEntity>
	{
		return this._tasks;
	}
	
	set tasks(value: Array<TaskEntity>)
	{
		this._tasks = value;
	}
	
	async save(): Promise<ResponseResultSet>
	{
		throw new Error('not implemented');
	}
}