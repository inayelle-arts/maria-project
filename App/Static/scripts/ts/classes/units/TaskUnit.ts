import {UnitBase} from "./UnitBase";
import {TaskEntity} from "../entities/TaskEntity";
import {TaskComponent} from "../components/TaskComponent";
import {MoreModalComponent} from "../components/modals/MoreModalComponent";

export class TaskUnit extends UnitBase<TaskEntity, TaskComponent>
{
	private readonly _moreModalComponent: MoreModalComponent;
	
	constructor(entity: TaskEntity)
	{
		const id = 'task_' + entity.id;
		const component = new TaskComponent(id);
		super(entity, component);
		
		this._moreModalComponent = new MoreModalComponent('more-task-modal');
		
		this.initialize();
	}
	
	private initialize(): void
	{
		this.Component.Name = this.Entity.name;
		this.Component.Code = this.Entity.code;
		
		let shortDescription = this.Entity.description;
		if (shortDescription.length > 60)
		{
			shortDescription = shortDescription.replace(/^(.{50}[^\s]*).*/, "$1") + '...';
		}
		
		this.Component.Description = shortDescription;
		
		this.bindEvents();
	}
	
	private bindEvents(): void
	{
		const c = this.Component;
		
		c.jFindByClass('task-action-more').bind('click', () =>
		{
			this._moreModalComponent.showWithTask(this.Entity);
		});
	}
}