import {UnitBase} from "./UnitBase";
import {BoardEntity} from "../entities/BoardEntity";
import {BoardComponent} from "../components/BoardComponent";
import {ColumnUnit} from "./ColumnUnit";
import {ColumnEntity} from "../entities/ColumnEntity";
import {TaskUnit} from "./TaskUnit";
import {TaskEntity} from "../entities/TaskEntity";

export class BoardUnit extends UnitBase<BoardEntity, BoardComponent>
{
	private readonly _columnUnits: Array<ColumnUnit>;
	
	constructor(entity: BoardEntity)
	{
		const id = 'board_' + entity.id;
		const component = new BoardComponent(id);
		super(entity, component);
		
		this._columnUnits = new Array<ColumnUnit>();
		
		this.initialize();
	}
	
	private initialize(): void
	{
		this.Component.BoardName = this.Entity.name;
		this.Component.ProjectName = this.Entity.project.name;
		
		this.Entity.columns.forEach((entity: ColumnEntity) =>
		{
			const unit = new ColumnUnit(entity);
			
			this._columnUnits.push(unit);
			
			this.Component.addColumnComponent(unit.Component);
		});
	}
	
	public getColumnUnitsExcept(entityId: number): Array<ColumnUnit>
	{
		return this._columnUnits.filter(x => x.Entity.id != entityId);
	}
	
	public getExactColumnUnit(entityId: number): ColumnUnit
	{
		return this._columnUnits.find(x => x.Entity.id == entityId);
	}
	
	public getTaskUnitsExcept(taskId: number): Array<TaskUnit>
	{
		const result = new Array<TaskUnit>();
		
		this._columnUnits.forEach((c: ColumnUnit) =>
		{
			c.TaskUnits.forEach((t: TaskUnit) =>
			{
				if (t.Entity.id != taskId)
				{
					result.push(t);
				}
			});
		});
		
		return result;
	}
}