import {RepositoryManager} from "../repos/RepositoryManager";

export abstract class EntityBase
{
	private static readonly _manager : RepositoryManager = RepositoryManager.Instance;
	
	protected get Manager() : RepositoryManager
	{
		return EntityBase._manager;
	}
	
	public abstract save() : boolean;
}