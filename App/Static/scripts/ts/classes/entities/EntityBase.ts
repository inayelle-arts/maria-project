import {ResponseResultSet} from "../repos/ResponseResultSet";

export abstract class EntityBase
{
	public abstract async save() : Promise<ResponseResultSet>;
}