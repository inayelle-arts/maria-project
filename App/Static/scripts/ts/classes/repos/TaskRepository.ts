import {TaskEntity} from "../entities/TaskEntity";
import {RepositoryBase} from "./RepositoryBase";

export class TaskRepository extends RepositoryBase<TaskEntity>
{
	add(entity: TaskEntity): boolean
	{
		return false;
	}
	
	delete(entity: TaskEntity): boolean
	{
		return false;
	}
	
	get(id: number): TaskEntity
	{
		return undefined;
	}
	
	getAll(): TaskEntity[]
	{
		return [];
	}
	
	update(entity: TaskEntity): boolean
	{
		return false;
	}
}