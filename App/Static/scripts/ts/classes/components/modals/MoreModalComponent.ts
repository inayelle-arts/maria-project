import {CompositeComponentBase} from "../base/CompositeComponentBase";
import {TaskEntity} from "../../entities/TaskEntity";
import {JFactory} from "../JFactory";
import {UnitManager} from "../../units/UnitManager";
import {SequentialContraintEntity} from "../../entities/SequentialContraintEntity";
import {ErrorModalComponent} from "./ErrorModalComponent";
import {TaskUnit} from "../../units/TaskUnit";

export class MoreModalComponent extends CompositeComponentBase
{
	private readonly taskName: JQuery<HTMLElement>;
	private readonly taskCode: JQuery<HTMLElement>;
	private readonly taskDescription: JQuery<HTMLElement>;
	private readonly taskCreatedAt: JQuery<HTMLElement>;
	private readonly taskNowIn: JQuery<HTMLElement>;
	private readonly taskCreator: JQuery<HTMLElement>;
	private readonly taskAssignee: JQuery<HTMLElement>;
	
	private entity: TaskEntity;
	
	constructor(id: string)
	{
		super(id);
		
		this.taskName = JFactory.getById('more-task-name');
		this.taskCode = JFactory.getById('more-task-code');
		this.taskDescription = JFactory.getById('more-task-description');
		this.taskCreatedAt = JFactory.getById('more-task-created-at');
		this.taskNowIn = JFactory.getById('more-task-now-in');
		this.taskCreator = JFactory.getById('more-task-creator');
		this.taskAssignee = JFactory.getById('more-task-assignee');
	}
	
	public showWithTask(entity: TaskEntity): void
	{
		this.entity = entity;
		this.bindValues();
		
		$('#more-task-add-parent').bind('click', () =>
		{
			this.loadOtherTasks();
		});
		
		// @ts-ignore
		this.JDom.modal();
	}
	
	private loadOtherTasks()
	{
		const boardUnit = UnitManager.getInstance().BoardUnit;
		console.log('add parent click [' + this.entity.id + ']');
		
		const taskList = this.jFindByClass('dropdown-primary');
		taskList.html('');
		
		const otherTasks = boardUnit.getTaskUnitsExcept(this.entity.id);
		
		otherTasks.forEach((unit: TaskUnit) =>
		{
			const elem = $(`<div style="color: black;" class="dropdown-item text-right" 
style="font-size: 10px; max-width: 20% !important;">
${unit.Entity.name} #${unit.Entity.code}
</div>`);
			
			taskList.append(elem);
			
			elem.bind('click', () =>
			{
				$('#more-task-add-parent').unbind().focusout();
				const parentTaskId = unit.Entity.id;
				const ownerTaskId = this.entity.id;
				
				const constraint = new SequentialContraintEntity();
				constraint.parentTaskId = parentTaskId;
				constraint.ownerId = ownerTaskId;
				
				constraint.save().then((resultSet) =>
				{
					const modal = ErrorModalComponent.getInstance();
					if (resultSet.status == '0')
					{
						modal.showWithMessage('Constraint added');
					} else
					{
						modal.showWithMessage(resultSet.message);
					}
				});
			});
		});
	}
	
	private bindValues(): void
	{
		const e = this.entity;
		
		this.TaskName = e.name;
		this.TaskDescription = e.description;
		this.TaskCode = e.code;
	}
	
	public set TaskName(value: string)
	{
		this.taskName.text(value);
	}
	
	public set TaskDescription(value: string)
	{
		this.taskDescription.text(value);
	}
	
	public set TaskCode(value: string)
	{
		this.taskCode.text(value);
	}
	
	public set TaskCreatedAt(value: string)
	{
		this.taskCreatedAt.text(value);
	}
	
	public set TaskNowIn(value: string)
	{
		this.taskNowIn.text(value);
	}
	
	public set TaskCreator(value: string)
	{
		this.taskCreator.text(value);
	}
	
	public set TaskAssignee(value: string)
	{
		this.taskDescription.text(value);
	}
}
