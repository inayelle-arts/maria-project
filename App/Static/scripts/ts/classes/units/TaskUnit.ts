import {UnitBase} from "./UnitBase";
import {TaskEntity} from "../entities/TaskEntity";
import {TaskComponent} from "../components/TaskComponent";

export class TaskUnit extends UnitBase<TaskEntity, TaskComponent>
{
	protected initialize(): void
	{
	}
}