import {LayoutRepository} from "../repos/LayoutRepository";

export abstract class ComponentBase
{
	private static readonly _layoutRepository: LayoutRepository = new LayoutRepository();
	
	protected static get LayoutRepository(): LayoutRepository
	{
		return ComponentBase._layoutRepository;
	}
}