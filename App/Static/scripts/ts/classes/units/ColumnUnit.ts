import {UnitBase} from "./UnitBase";
import {ColumnEntity} from "../entities/ColumnEntity";
import {ColumnComponent} from "../components/ColumnComponent";
import {TaskEntity} from "../entities/TaskEntity";
import {TaskUnit} from "./TaskUnit";

export class ColumnUnit extends UnitBase<ColumnEntity, ColumnComponent>
{
	private readonly _taskUnits: Array<TaskUnit>;
	
	constructor(entity: ColumnEntity)
	{
		const id = 'column-' + entity.Id;
		const component = new ColumnComponent(id);
		super(entity, component);
		
		this._taskUnits = new Array<TaskUnit>();
		
		this.initialize();
	}
	
	protected initialize(): void
	{
		this.Component.Name = this.Entity.getName();
		
		this.Entity.Tasks.forEach((entity: TaskEntity) =>
		{
			const unit = new TaskUnit(entity);
			
			this._taskUnits.push(unit);
			
			this.Component.addTaskComponent(unit.Component);	
		});
	}
}