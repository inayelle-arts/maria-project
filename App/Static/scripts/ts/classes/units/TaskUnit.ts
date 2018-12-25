import {UnitBase} from "./UnitBase";
import {TaskEntity} from "../entities/TaskEntity";
import {TaskComponent} from "../components/TaskComponent";

export class TaskUnit extends UnitBase<TaskEntity, TaskComponent>
{
	constructor(entity: TaskEntity)
	{
		const id = 'task-' + entity.Id;
		const component = new TaskComponent(id);
		super(entity, component);
		
		this.initialize();
	}
	
	protected initialize(): void
	{
		this.Component.Name = this.Entity.getName();
	}
}