'use strict';

customElements.define('compodoc-menu', class extends HTMLElement {
    constructor() {
        super();
        this.isNormalMode = this.getAttribute('mode') === 'normal';
    }

    connectedCallback() {
        this.render(this.isNormalMode);
    }

    render(isNormalMode) {
        let tp = lithtml.html(`
        <nav>
            <ul class="list">
                <li class="title">
                    <a href="index.html" data-type="index-link">spaangular documentation</a>
                </li>

                <li class="divider"></li>
                ${ isNormalMode ? `<div id="book-search-input" role="search"><input type="text" placeholder="Type to search"></div>` : '' }
                <li class="chapter">
                    <a data-type="chapter-link" href="index.html"><span class="icon ion-ios-home"></span>Getting started</a>
                    <ul class="links">
                        <li class="link">
                            <a href="overview.html" data-type="chapter-link">
                                <span class="icon ion-ios-keypad"></span>Overview
                            </a>
                        </li>
                        <li class="link">
                            <a href="index.html" data-type="chapter-link">
                                <span class="icon ion-ios-paper"></span>README
                            </a>
                        </li>
                                <li class="link">
                                    <a href="dependencies.html" data-type="chapter-link">
                                        <span class="icon ion-ios-list"></span>Dependencies
                                    </a>
                                </li>
                                <li class="link">
                                    <a href="properties.html" data-type="chapter-link">
                                        <span class="icon ion-ios-apps"></span>Properties
                                    </a>
                                </li>
                    </ul>
                </li>
                    <li class="chapter modules">
                        <a data-type="chapter-link" href="modules.html">
                            <div class="menu-toggler linked" data-bs-toggle="collapse" ${ isNormalMode ?
                                'data-bs-target="#modules-links"' : 'data-bs-target="#xs-modules-links"' }>
                                <span class="icon ion-ios-archive"></span>
                                <span class="link-name">Modules</span>
                                <span class="icon ion-ios-arrow-down"></span>
                            </div>
                        </a>
                        <ul class="links collapse " ${ isNormalMode ? 'id="modules-links"' : 'id="xs-modules-links"' }>
                            <li class="link">
                                <a href="modules/AppModule.html" data-type="entity-link" >AppModule</a>
                                    <li class="chapter inner">
                                        <div class="simple menu-toggler" data-bs-toggle="collapse" ${ isNormalMode ?
                                            'data-bs-target="#components-links-module-AppModule-e4b8bc8a676f85bcf5e9057d250a65f07d8dcefa7651d85afff46e213cc3a1d312c5d04317eb949e67b51a87e9d9fd34043eca6ded7fbcbbf6fbd09cc4e4baf3"' : 'data-bs-target="#xs-components-links-module-AppModule-e4b8bc8a676f85bcf5e9057d250a65f07d8dcefa7651d85afff46e213cc3a1d312c5d04317eb949e67b51a87e9d9fd34043eca6ded7fbcbbf6fbd09cc4e4baf3"' }>
                                            <span class="icon ion-md-cog"></span>
                                            <span>Components</span>
                                            <span class="icon ion-ios-arrow-down"></span>
                                        </div>
                                        <ul class="links collapse" ${ isNormalMode ? 'id="components-links-module-AppModule-e4b8bc8a676f85bcf5e9057d250a65f07d8dcefa7651d85afff46e213cc3a1d312c5d04317eb949e67b51a87e9d9fd34043eca6ded7fbcbbf6fbd09cc4e4baf3"' :
                                            'id="xs-components-links-module-AppModule-e4b8bc8a676f85bcf5e9057d250a65f07d8dcefa7651d85afff46e213cc3a1d312c5d04317eb949e67b51a87e9d9fd34043eca6ded7fbcbbf6fbd09cc4e4baf3"' }>
                                            <li class="link">
                                                <a href="components/AppComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules" >AppComponent</a>
                                            </li>
                                            <li class="link">
                                                <a href="components/DeleteMessageComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules" >DeleteMessageComponent</a>
                                            </li>
                                            <li class="link">
                                                <a href="components/DeviceListComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules" >DeviceListComponent</a>
                                            </li>
                                            <li class="link">
                                                <a href="components/MessageListComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules" >MessageListComponent</a>
                                            </li>
                                        </ul>
                                    </li>
                                <li class="chapter inner">
                                    <div class="simple menu-toggler" data-bs-toggle="collapse" ${ isNormalMode ?
                                        'data-bs-target="#injectables-links-module-AppModule-e4b8bc8a676f85bcf5e9057d250a65f07d8dcefa7651d85afff46e213cc3a1d312c5d04317eb949e67b51a87e9d9fd34043eca6ded7fbcbbf6fbd09cc4e4baf3"' : 'data-bs-target="#xs-injectables-links-module-AppModule-e4b8bc8a676f85bcf5e9057d250a65f07d8dcefa7651d85afff46e213cc3a1d312c5d04317eb949e67b51a87e9d9fd34043eca6ded7fbcbbf6fbd09cc4e4baf3"' }>
                                        <span class="icon ion-md-arrow-round-down"></span>
                                        <span>Injectables</span>
                                        <span class="icon ion-ios-arrow-down"></span>
                                    </div>
                                    <ul class="links collapse" ${ isNormalMode ? 'id="injectables-links-module-AppModule-e4b8bc8a676f85bcf5e9057d250a65f07d8dcefa7651d85afff46e213cc3a1d312c5d04317eb949e67b51a87e9d9fd34043eca6ded7fbcbbf6fbd09cc4e4baf3"' :
                                        'id="xs-injectables-links-module-AppModule-e4b8bc8a676f85bcf5e9057d250a65f07d8dcefa7651d85afff46e213cc3a1d312c5d04317eb949e67b51a87e9d9fd34043eca6ded7fbcbbf6fbd09cc4e4baf3"' }>
                                        <li class="link">
                                            <a href="injectables/LogPublishersService.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules" >LogPublishersService</a>
                                        </li>
                                        <li class="link">
                                            <a href="injectables/LogService.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules" >LogService</a>
                                        </li>
                                    </ul>
                                </li>
                            </li>
                </ul>
                </li>
                    <li class="chapter">
                        <div class="simple menu-toggler" data-bs-toggle="collapse" ${ isNormalMode ? 'data-bs-target="#classes-links"' :
                            'data-bs-target="#xs-classes-links"' }>
                            <span class="icon ion-ios-paper"></span>
                            <span>Classes</span>
                            <span class="icon ion-ios-arrow-down"></span>
                        </div>
                        <ul class="links collapse " ${ isNormalMode ? 'id="classes-links"' : 'id="xs-classes-links"' }>
                            <li class="link">
                                <a href="classes/LogConsole.html" data-type="entity-link" >LogConsole</a>
                            </li>
                            <li class="link">
                                <a href="classes/LogLocalStorage.html" data-type="entity-link" >LogLocalStorage</a>
                            </li>
                            <li class="link">
                                <a href="classes/LogMessage.html" data-type="entity-link" >LogMessage</a>
                            </li>
                            <li class="link">
                                <a href="classes/LogPublisher.html" data-type="entity-link" >LogPublisher</a>
                            </li>
                            <li class="link">
                                <a href="classes/LogWebApi.html" data-type="entity-link" >LogWebApi</a>
                            </li>
                        </ul>
                    </li>
                        <li class="chapter">
                            <div class="simple menu-toggler" data-bs-toggle="collapse" ${ isNormalMode ? 'data-bs-target="#injectables-links"' :
                                'data-bs-target="#xs-injectables-links"' }>
                                <span class="icon ion-md-arrow-round-down"></span>
                                <span>Injectables</span>
                                <span class="icon ion-ios-arrow-down"></span>
                            </div>
                            <ul class="links collapse " ${ isNormalMode ? 'id="injectables-links"' : 'id="xs-injectables-links"' }>
                                <li class="link">
                                    <a href="injectables/DataService.html" data-type="entity-link" >DataService</a>
                                </li>
                                <li class="link">
                                    <a href="injectables/LogPublishersService.html" data-type="entity-link" >LogPublishersService</a>
                                </li>
                                <li class="link">
                                    <a href="injectables/LogService.html" data-type="entity-link" >LogService</a>
                                </li>
                            </ul>
                        </li>
                    <li class="chapter">
                        <div class="simple menu-toggler" data-bs-toggle="collapse" ${ isNormalMode ? 'data-bs-target="#interfaces-links"' :
                            'data-bs-target="#xs-interfaces-links"' }>
                            <span class="icon ion-md-information-circle-outline"></span>
                            <span>Interfaces</span>
                            <span class="icon ion-ios-arrow-down"></span>
                        </div>
                        <ul class="links collapse " ${ isNormalMode ? ' id="interfaces-links"' : 'id="xs-interfaces-links"' }>
                            <li class="link">
                                <a href="interfaces/Message.html" data-type="entity-link" >Message</a>
                            </li>
                        </ul>
                    </li>
                    <li class="chapter">
                        <div class="simple menu-toggler" data-bs-toggle="collapse" ${ isNormalMode ? 'data-bs-target="#miscellaneous-links"'
                            : 'data-bs-target="#xs-miscellaneous-links"' }>
                            <span class="icon ion-ios-cube"></span>
                            <span>Miscellaneous</span>
                            <span class="icon ion-ios-arrow-down"></span>
                        </div>
                        <ul class="links collapse " ${ isNormalMode ? 'id="miscellaneous-links"' : 'id="xs-miscellaneous-links"' }>
                            <li class="link">
                                <a href="miscellaneous/enumerations.html" data-type="entity-link">Enums</a>
                            </li>
                        </ul>
                    </li>
                        <li class="chapter">
                            <a data-type="chapter-link" href="routes.html"><span class="icon ion-ios-git-branch"></span>Routes</a>
                        </li>
                    <li class="chapter">
                        <a data-type="chapter-link" href="coverage.html"><span class="icon ion-ios-stats"></span>Documentation coverage</a>
                    </li>
                    <li class="divider"></li>
                    <li class="copyright">
                        Documentation generated using <a href="https://compodoc.app/" target="_blank" rel="noopener noreferrer">
                            <img data-src="images/compodoc-vectorise.png" class="img-responsive" data-type="compodoc-logo">
                        </a>
                    </li>
            </ul>
        </nav>
        `);
        this.innerHTML = tp.strings;
    }
});