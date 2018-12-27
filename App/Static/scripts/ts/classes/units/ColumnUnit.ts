import {UnitBase} from "./UnitBase";
import {ColumnEntity} from "../entities/ColumnEntity";
import {ColumnComponent} from "../components/ColumnComponent";
import {TaskEntity} from "../entities/TaskEntity";
import {TaskUnit} from "./TaskUnit";
import {NewTaskModalComponent} from "../components/modals/NewTaskModalComponent";

export class ColumnUnit extends UnitBase<ColumnEntity, ColumnComponent>
{
	private readonly _newTaskModal: NewTaskModalComponent;
	private readonly _taskUnits: Array<TaskUnit>;
	private static _nextId: number = 1;
	
	constructor(entity: ColumnEntity)
	{
		const id = 'column_' + entity.id;
		const component = new ColumnComponent(id);
		super(entity, component);
		
		this._newTaskModal = new NewTaskModalComponent();
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
		
		this._newTaskModal.showModal((name: string, description: string) =>
		{
			this.createNewTask(name, description);
		});
	}
	
	private onSettingsButtonClick()
	{
		console.log('settings click [' + this.Entity.id + ']');
	}
	
	private createNewTask(name: string, description: string): void
	{
		console.log(name + " created");
		
		const entity = new TaskEntity();
		entity.id = null;
		entity.name = name.trim();
		entity.description = description.trim();
		entity.columnId = this.Entity.id;
		
		entity.save().then(() =>
		{
			const unit = new TaskUnit(entity);
			this._taskUnits.push(unit);
			this.Component.addTaskComponent(unit.Component);
			unit.Component.JDom.attr('id', this.Component.Id + '_' + entity.id);
			unit.Component.Code = entity.code;
		});
	}
}