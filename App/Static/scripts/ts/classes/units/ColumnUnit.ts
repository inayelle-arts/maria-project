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
		const id = 'column_' + entity.id;
		const component = new ColumnComponent(id);
		super(entity, component);
		
		this._taskUnits = new Array<TaskUnit>();
		
		this.initialize();
	}
	
	private initialize(): void
	{
		this.Component.Name = this.Entity.name;
		
		this.Entity.tasks.forEach((entity: TaskEntity) =>
		{
			const unit = new TaskUnit(entity);
			
			this._taskUnits.push(unit);
			
			this.Component.addTaskComponent(unit.Component);
		});
		
		this.bindEvents();
	}
	
	private bindEvents(): void
	{
		this.Component.AddTaskButtonJDom.bind('click', () =>
		{
			this.onAddTaskButtonClick();
		});
		
		this.Component.SettingsButtonJDom.bind('click', () =>
		{
			this.onSettingsButtonClick();
		});
	}
	
	private onAddTaskButtonClick()
	{
		console.log('add task click [' + this.Entity.id + ']');
	}
	
	private onSettingsButtonClick()
	{
		console.log('settings click [' + this.Entity.id + ']');
	}
}