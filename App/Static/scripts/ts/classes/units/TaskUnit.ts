import {UnitBase} from "./UnitBase";
import {TaskEntity} from "../entities/TaskEntity";
import {TaskComponent} from "../components/TaskComponent";
import {MoreModalComponent} from "../components/modals/MoreModalComponent";
import {UnitManager} from "./UnitManager";
import {ColumnUnit} from "./ColumnUnit";
import {ErrorModalComponent} from "../components/modals/ErrorModalComponent";
import {SequentialContraintEntity} from "../entities/SequentialContraintEntity";

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
		this.Component.Code = this.Entity.code == undefined ? "new" : this.Entity.code;
		
		// 	<div class="task-code-parent badge badge-light task-non-action">
		// 		**Task code**
		// </div>
		
		const jParentCodes = this.Component.JDom;
		this.Entity.constraints.forEach((constr) =>
		{
			jParentCodes.append(`
		 	<div class="task-code-parent badge badge-light task-non-action" style="font-size: 10px !important;">
				${constr.parentTaskId}
			</div>`);
		});
		
		let shortDescription = this.Entity.description;
		if (shortDescription != null && shortDescription.length > 60)
		{
			shortDescription = shortDescription.replace(/^(.{50}[^\s]*).*/, "$1") + '...';
		}
		
		this.Component.Description = shortDescription;
		
		this.bindEvents();
	}
	
	private bindEvents(): void
	{
		const cComponent = this.Component;
		
		cComponent.jFindByClass('task-action-more').bind('click', () =>
		{
			this._moreModalComponent.showWithTask(this.Entity);
		});
		
		cComponent.jFindByClass('task-action-move').bind('click', () =>
		{
			this.fixEntity();
			this.taskActionMove();
		});
		
		cComponent.jFindByClass('task-action-add-parent').bind('click', () =>
		{
			this.fixEntity();
			this.taskActionAddParent();
		});
	}
	
	private fixEntity()
	{
		const e = this.Entity;
		const realEntity = new TaskEntity();
		realEntity.id = e.id;
		realEntity.columnId = e.columnId;
		realEntity.code = e.code;
		realEntity.description = e.description;
		realEntity.name = e.name;
		realEntity.creatorId = e.creatorId;
		realEntity.constraints = this.Entity.constraints;
		this.Entity = realEntity;
	}
	
	private taskActionMove()
	{
		const boardUnit = UnitManager.getInstance().BoardUnit;
		console.log('move click [' + this.Entity.id + ']');
		
		const columns = boardUnit.getColumnUnitsExcept(this.Entity.columnId);
		const currentColumn = boardUnit.getExactColumnUnit(this.Entity.columnId);
		
		const colList = this.Component.jFindByClass('dropdown-primary');
		colList.html('');
		
		columns.forEach((c: ColumnUnit) =>
		{
			const elem = $(`<div style="color: black;" class="dropdown-item">${c.Entity.name}</div>`);
			colList.append(elem);
			elem.bind('click', () =>
			{
				const targetColId = c.Entity.id;
				
				console.log('THIS ENTITY ID: ' + this.Entity.id);
				this.Entity.moveToColumnAsync(targetColId).then((resultSet) =>
				{
					if (resultSet.status == '0')
					{
						this.Entity.columnId = targetColId;
						currentColumn.Component.removeTaskComponent(this.Component);
						c.Component.addTaskComponent(this.Component);
						this.bindEvents();
						this.Component.initialize();
					} else
					{
						ErrorModalComponent.getInstance().showWithMessage(resultSet.message, resultSet.data.toString());
					}
				});
			});
		});
	}
	
	private taskActionAddParent()
	{
		
	}
}