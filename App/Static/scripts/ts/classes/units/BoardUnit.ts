import {UnitBase} from "./UnitBase";
import {BoardEntity} from "../entities/BoardEntity";
import {BoardComponent} from "../components/BoardComponent";

export class BoardUnit extends UnitBase<BoardEntity, BoardComponent>
{
	protected initialize(): void
	{
	}
}