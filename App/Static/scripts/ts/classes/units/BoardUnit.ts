import {UnitBase} from "./UnitBase";
import {BoardEntity} from "../entities/BoardEntity";
import {BoardComponent} from "../components/BoardComponent";
import {ColumnUnit} from "./ColumnUnit";
import {ColumnEntity} from "../entities/ColumnEntity";

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
		this.Component.Name = this.Entity.name;
		
		this.Entity.columns.forEach((entity: ColumnEntity) =>
		{
			const unit = new ColumnUnit(entity);
			
			this._columnUnits.push(unit);
			
			this.Component.addColumnComponent(unit.Component);
		});
	}
}